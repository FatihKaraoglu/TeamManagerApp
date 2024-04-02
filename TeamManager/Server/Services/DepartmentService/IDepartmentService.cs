namespace TeamManager.Server.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<Department>>> GetDepartments();
        Task<ServiceResponse<Department>> GetDepartment(string departmentName);
        Task<ServiceResponse<bool>> AddDepartment(Department department);
        Task<ServiceResponse<bool>> EditDepartment(string departmentName, Department updatedDepartment);

    }
}
