namespace TeamManager.Server.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Department>>> GetDepartments()
        {
            var response = new ServiceResponse<List<Department>>();
            try
            {
                response.Data = await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Department>> GetDepartment(string departmentName)
        {
            var response = new ServiceResponse<Department>();
            try
            {
                response.Data = await _context.Departments.FirstOrDefaultAsync(d => d.Name == departmentName);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = "Department not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> AddDepartment(Department department)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> EditDepartment(string departmentName, Department updatedDepartment)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.Name == departmentName);
                if (existingDepartment != null)
                {
                    existingDepartment.Name = updatedDepartment.Name;
                    // Update other properties as needed
                    await _context.SaveChangesAsync();
                    response.Data = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Department not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

