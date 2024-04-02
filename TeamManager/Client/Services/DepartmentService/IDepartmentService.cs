using TeamManager.Shared.DTO;

namespace TeamManager.Client.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<Department>>> GetDepartments();
    }
}
