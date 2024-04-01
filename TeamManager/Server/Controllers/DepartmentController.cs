using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Server.Services.DepartmentService;

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
        public async Task<ActionResult<ServiceResponse<List<Department>>>> GetDepartments()
        {
            var response = await _departmentService.GetDepartments();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{departmentName}")]
        public async Task<ActionResult<ServiceResponse<Department>>> GetDepartment(string departmentName)
        {
            var response = await _departmentService.GetDepartment(departmentName);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> AddDepartment(Department department)
        {
            var response = await _departmentService.AddDepartment(department);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{departmentName}")]
        public async Task<ActionResult<ServiceResponse<bool>>> EditDepartment(string departmentName, Department updatedDepartment)
        {
            var response = await _departmentService.EditDepartment(departmentName, updatedDepartment);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
