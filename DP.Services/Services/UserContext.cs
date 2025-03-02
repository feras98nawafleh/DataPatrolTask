using DP.Core.Entities;
using DP.Infrastructure.Data;
using DP.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DP.Services.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public UserContext(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<User> GetCurrentUserAsync()
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == this.UserId);
            return currentUser;
        }

        public string? UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value ?? "";
                if (!string.IsNullOrEmpty(userIdClaim))
                {
                    return userIdClaim;
                }
                return null;
            }
        }
        public bool? IsDisabled
        {
            get
            {
                return false;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
            }
        }
    }
}
