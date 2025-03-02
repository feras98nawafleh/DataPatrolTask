using DP.Core.Builders;
using DP.Core.DTOs;
using DP.Core.Entities;
using DP.Core.Models;
using DP.Infrastructure.Data;
using DP.Services.Interfaces;
using DP.Services.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DP.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IValidationService _validationService;
        private readonly IValidationServiceGeneric _validationServiceGeneric;
        private readonly IConfiguration _configuration;
        private readonly IUserContext _userContext;

        public AuthService(AppDbContext context, IValidationService validationService, IValidationServiceGeneric validationServiceGeneric, IConfiguration configuration, IUserContext userContext)
        {
            _context = context;
            _validationService = validationService;
            _validationServiceGeneric = validationServiceGeneric;
            _configuration = configuration;
            _userContext = userContext;
        }
        public async Task<ResponseEnvelope<UserLoginResponseDTO>> LoginAsync(UserLoginRequestDTO userLoginDTO)
        {
            await _validationServiceGeneric.CheckEntityExistsAsync<User>(u => u.Username == userLoginDTO.Username || u.UserId == userLoginDTO.Username, "User not found!");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLoginDTO.Username || u.UserId == userLoginDTO.Username);

            if (user == null || !_validationService.CheckPasswordMatchHash(userLoginDTO.Password, user.PasswordHash))
            {
                throw new CustomException("Invalid username or password.");
            }

            await _validationService.CheckUserExistsAndEnabledAsync(user.UserId);

            var userLoginResponse = new UserLoginResponseDTO
            {
                UserId = user.UserId,
                IsEnabled = user.IsEnabled,
                Token = TokenGenerator(user)
            };

            return new ResponseEnvelopeBuilder<UserLoginResponseDTO>()
                .WithSuccess()
                .WithData(userLoginResponse)
                .WithStatusCode(System.Net.HttpStatusCode.OK)
                .Build();
        }

        public async Task<ResponseEnvelope<UserLoginResponseDTO>> RegisterAsync(UserLoginRequestDTO userLoginDTO)
        {
            var (exists, suggestedUsername) = _validationService.CheckUsernameExists(userLoginDTO.Username);

            if (exists)
            {
                userLoginDTO.Username = suggestedUsername;
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userLoginDTO.Password);

            var user = new User.UserBuilder()
                .SetUserId(userLoginDTO.Username)
                .SetUsername(userLoginDTO.Username)
                .SetPasswordHash(passwordHash)
                .SetIsEnabled(true)
                .SetCreationDate(DateTime.Now)
                .Build();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userLoginResponse = await LoginAsync(userLoginDTO);

            return new ResponseEnvelopeBuilder<UserLoginResponseDTO>()
                .WithSuccess()
                .WithData(userLoginResponse.Data)
                .WithStatusCode(System.Net.HttpStatusCode.OK)
                .Build();
        }

        private string TokenGenerator(User? user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("UserId", user.UserId),
                new Claim("IsEnabled", user.IsEnabled.ToString(), ClaimValueTypes.Boolean),
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
