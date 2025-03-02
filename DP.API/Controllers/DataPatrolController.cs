using DP.Core.DTOs;
using DP.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DP.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DataPatrolController : ControllerBase
    {
        IAuthService _authService;
        IRequestService _requestService;
        public DataPatrolController(IAuthService authService, IRequestService requestService)
        {
            _authService = authService;
            _requestService = requestService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginRequestDTO userLoginRequest)
        {
            var response = await _authService.LoginAsync(userLoginRequest);
            Log.Information(messageTemplate: "DataPatrolController/login responded with {@response}", response);
            return Ok(response);
        }

        [HttpPost("reg")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(UserLoginRequestDTO userLoginRequest)
        {
            var response = await _authService.RegisterAsync(userLoginRequest);
            Log.Information(messageTemplate: "DataPatrolController/reg responded with {@response}", response);
            return Ok(response);
        }

        [HttpPost("request/create")]
        public async Task<IActionResult> CreateRequest(NewRequestDTO newRequest)
        {
            var response = await _requestService.CreateRequestAsync(newRequest);
            Log.Information(messageTemplate: "DataPatrolController/request/create responded with {@response}", response);
            return Ok(response);
        }

        [HttpPost("request/summary")]
        public async Task<IActionResult> UserRequests(string userid)
        {
            var response = await _requestService.GetUserRequestsAsync(userid);
            Log.Information(messageTemplate: "DataPatrolController/request/summary responded with {@response}", response);
            return Ok(response);
        }
    }
}
