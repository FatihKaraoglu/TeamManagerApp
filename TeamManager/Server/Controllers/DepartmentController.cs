using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Server.Services.DepartmentService;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DepartmentDTO>>>> GetDepartments()
        {
            var response = await _departmentService.GetDepartments();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{departmentName}")]
        public async Task<ActionResult<ServiceResponse<DepartmentDTO>>> GetDepartment(string departmentName)
        {
            var response = await _departmentService.GetDepartment(departmentName);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> AddDepartment(DepartmentDTO department)
        {
            var response = await _departmentService.AddDepartment(department);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("EditDepartment")]
        public async Task<ActionResult<ServiceResponse<bool>>> EditDepartment(int departmentId, DepartmentDTO updatedDepartment)
        {
            var response = await _departmentService.EditDepartment(departmentId, updatedDepartment);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("DeleteDepartment")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteDepartment(int departmentId)
        {
            var response = await _departmentService.DeleteDepartment(departmentId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
