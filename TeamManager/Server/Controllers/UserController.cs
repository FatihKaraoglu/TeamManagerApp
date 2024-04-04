using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Server.Services.UserService;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("AllUsers")]
        public async Task<ActionResult<ServiceResponse<List<UserDTO>>>> GetAllUsers()
        {
           var users =  await _userService.GetUsers();


            if(users.Count == 0 || users == null)
            {
                return new ServiceResponse<List<UserDTO>>()
                {
                    Data = users,
                    Message = "No Users have been found!",
                    Success = true
                };
            }

            var response = new ServiceResponse<List<UserDTO>>()
            {
                Data = users,
                Success = true

            };

            return Ok(response);
        
        }


        [HttpGet("EmployeesNotAssigned")]
        public async Task<ActionResult<ServiceResponse<List<UserDTO>>>> GetNotAssignedEmployees()
        {
            var users = await _userService.GetEmployeesNotAssigned();


            if (users.Count == 0 || users == null)
            {
                return new ServiceResponse<List<UserDTO>>()
                {
                    Data = users,
                    Message = "No Employess that are not assigned to a Department have been found!",
                    Success = true
                };
            }

            var response = new ServiceResponse<List<UserDTO>>()
            {
                Data = users,
                Success = true

            };

            return Ok(response);

        }


        [HttpPost("AddEmployeeToDepartment")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddEmployeeToDepartment(EmployeeToDepartmentDTO dto)
        {
            var success = await _userService.AddUserToDepartment(dto.EmployeeId, dto.DepartmentId);
            return new ServiceResponse<bool>()
            {
                Data = success
            };
        }

    }
}
