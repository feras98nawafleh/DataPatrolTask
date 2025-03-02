using DP.Core.DTOs;
using DP.Core.Models;

namespace DP.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseEnvelope<UserLoginResponseDTO>> RegisterAsync(UserLoginRequestDTO userLoginDTO);
        Task<ResponseEnvelope<UserLoginResponseDTO>> LoginAsync(UserLoginRequestDTO userLoginDTO);
    }
}
