using TeamManager.Shared.DTO;

namespace TeamManager.Client.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<Department>>> GetDepartments();
        public Task<ServiceResponse<bool>> AddDepartment(DepartmentDTO department);
        public Task<ServiceResponse<bool>> DeleteDepartment(int departmentId);
    }
}
