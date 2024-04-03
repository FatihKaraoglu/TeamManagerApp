using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<DepartmentDTO>>> GetDepartments();
        Task<ServiceResponse<DepartmentDTO>> GetDepartment(string departmentName);
        Task<ServiceResponse<DepartmentDTO>> GetDepartment(int departmentName);
        Task<ServiceResponse<bool>> AddDepartment(DepartmentDTO department);
        Task<ServiceResponse<bool>> EditDepartment(int departmentId, DepartmentDTO updatedDepartment);
        Task<ServiceResponse<bool>> EditDepartment(string departmentName, DepartmentDTO updatedDepartment);


    }
}
