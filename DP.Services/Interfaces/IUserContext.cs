using DP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP.Services.Interfaces
{
    public interface IUserContext
    {
        Task<User> GetCurrentUserAsync();
        string? UserId { get; }
        bool? IsDisabled { get; }
        bool IsAuthenticated { get; }
    }
}
