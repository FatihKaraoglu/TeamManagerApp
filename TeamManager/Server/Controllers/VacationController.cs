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

        [HttpPost]
        public async Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO vacationRequestDTO)
        {
            bool exisiting = await _vacationService.CheckExistingVacation(vacationRequestDTO.StartDate, vacationRequestDTO.EndDate, vacationRequestDTO.UserId);
            if (exisiting)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "There is an overlapping Vacation!",
                    Data = false
                };
            }

            bool enoughRemainingBalance = await _vacationService.CheckRemainingVacation(vacationRequestDTO.StartDate, vacationRequestDTO.EndDate, vacationRequestDTO.UserId);
            if (!enoughRemainingBalance) 
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Not enough Vacation Days left!",
                    Data = false
                };
            }

            return new ServiceResponse<bool>
            {
                Success = true,
                Message = "Request has been made! Wait for your Employye to accept or deny your Request!",
                Data = true

            };
           
           
        }
    }
}
