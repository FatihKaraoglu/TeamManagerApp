using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TeamManager.Server.Services.VacationService;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }

        [HttpGet("VacationRequests")]
        public async Task<ServiceResponse<List<VacationRequest>>> GetVacationRequests()
        {
            var result = await _vacationService.GetVacationRequests();

            if(result.Count == 0)
            {
                return new ServiceResponse<List<VacationRequest>>()
                {
                    Message = "No Vacation Requests for this user!",
                    Data = new List<VacationRequest>(),
                    Success = true,
                };
            }

            return new ServiceResponse<List<VacationRequest>>()
            {
                Message = "",
                Data = result,
                Success = true,
            };
        }

        [HttpPost("VacationBalance")]
        public async Task<ServiceResponse<VacationBalance>> GetVacationBalance([FromBody] VacationBalanceRequestDTO requestDto)
        {
           return await _vacationService.GetVacationBalance(requestDto.Year);
        }

        [HttpPost("RequestVacation")]
        public async Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO vacationRequestDTO)
        {
           return await _vacationService.RequestVacation(vacationRequestDTO);
        }
    }
}
