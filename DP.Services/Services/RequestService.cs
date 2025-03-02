using DP.Core.Builders;
using DP.Core.DTOs;
using DP.Core.Entities;
using DP.Core.Models;
using DP.Infrastructure.Data;
using DP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static DP.Core.Enums.Enums;

namespace DP.Services.Services
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _context;
        private readonly IValidationService _validationService;
        private readonly IValidationServiceGeneric _validationServiceGeneric;
        private readonly IConfiguration _configuration;
        private readonly IUserContext _userContext;

        public RequestService(AppDbContext context, IValidationService validationService, IValidationServiceGeneric validationServiceGeneric, IConfiguration configuration, IUserContext userContext)
        {
            _context = context;
            _validationService = validationService;
            _validationServiceGeneric = validationServiceGeneric;
            _configuration = configuration;
            _userContext = userContext;
        }

        public async Task<ResponseEnvelope<RequestCreationResponse>> CreateRequestAsync(NewRequestDTO newRequestDTO)
        {
            await _validationService.CheckUserExistsAndEnabledAsync(newRequestDTO.UserId);

            var newRequest = new UserRequest.UserRequestBuilder()
                .SetRequestedBy(newRequestDTO.UserId)
                .SetRequestDateTime(DateTime.Now)
                .SetStatus(RequestStatus.Draft)
                .SetDescription(newRequestDTO.Description)
                .SetRequestCode((int)RequestStatus.Draft)
                .Build();

            _context.UserRequests.Add(newRequest);
            await _context.SaveChangesAsync();

            return new ResponseEnvelopeBuilder<RequestCreationResponse>()
                .WithSuccess()
                .WithData(new RequestCreationResponse() { RequestId = newRequest.RequestId })
                .WithStatusCode(System.Net.HttpStatusCode.OK)
                .Build();
        }

        public async Task<ResponseEnvelope<List<UserRequestsDTO>>> GetUserRequestsAsync(string userid)
        {
            await _validationServiceGeneric.CheckEntityExistsAsync<User>(u => u.UserId == userid && u.IsEnabled, "User not found!");
            var currentUser = await _userContext.GetCurrentUserAsync();

            if(currentUser.UserId != userid)
            {
                return new ResponseEnvelopeBuilder<List<UserRequestsDTO>>()
                    .WithSuccess()
                    .WithData(null)
                    .WithStatusCode(System.Net.HttpStatusCode.Unauthorized)
                    .Build();
            }

            var userRequests = await _context.UserRequests.AsNoTracking().Where(ur => ur.RequestedBy == userid).GroupBy(ur => ur.Status)
                .Select(g => new UserRequestsDTO()
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();

            return new ResponseEnvelopeBuilder<List<UserRequestsDTO>>()
                .WithSuccess()
                .WithData(userRequests)
                .WithStatusCode(System.Net.HttpStatusCode.OK)
                .Build();
        }
    }
}
