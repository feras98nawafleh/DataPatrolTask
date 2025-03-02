using DP.Core.DTOs;
using DP.Core.Entities;
using DP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP.Services.Interfaces
{
    public interface IRequestService
    {
        Task<ResponseEnvelope<RequestCreationResponse>> CreateRequestAsync(NewRequestDTO newRequestDTO);
        Task<ResponseEnvelope<List<UserRequestsDTO>>> GetUserRequestsAsync(string userid);
    }
}
