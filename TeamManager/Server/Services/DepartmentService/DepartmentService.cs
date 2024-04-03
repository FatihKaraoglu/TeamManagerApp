using TeamManager.Server.Services.UserService;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public DepartmentService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ServiceResponse<List<DepartmentDTO>>> GetDepartments()
        {
            var response = new ServiceResponse<List<DepartmentDTO>>();
            try
            {
                var departmentList = await _context.Departments.ToListAsync();

                var departmentDTOList = new List<DepartmentDTO>();

                foreach(var department in departmentList)
                {
                    departmentDTOList.Add
                        (
                            new DepartmentDTO()
                            {
                                Id = department.Id,
                                Name = department.Name,
                            }
                        );
                }

                response.Data = departmentDTOList;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<DepartmentDTO>> GetDepartment(string departmentName)
        {
            var response = new ServiceResponse<DepartmentDTO>();
            try
            {
                var department = await _context.Departments.FirstOrDefaultAsync(d => d.Name == departmentName);

                response.Data = new DepartmentDTO()
                {
                    Id = department.Id,
                    Name = department.Name
                };


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

        public async Task<ServiceResponse<DepartmentDTO>> GetDepartment(int departmentId)
        {
            var response = new ServiceResponse<DepartmentDTO>();
            try
            {

                var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);

                response.Data = new DepartmentDTO()
                {
                    Id = department.Id,
                    Name = department.Name
                };

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

        public async Task<ServiceResponse<bool>> AddDepartment(DepartmentDTO department)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                _context.Departments.Add(new Department()
                {
                    Id = department.Id,
                    Name = department.Name,
                });

                if(department.Employees != null && department.Employees.Count != 0)
                {
                    foreach(var employee in department.Employees)
                    {
                        _userService.AddUserToDepartment(employee.Id, department.Id);
                    }
                }

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

        public async Task<ServiceResponse<bool>> EditDepartment(int departmentId, DepartmentDTO updatedDepartment)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
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

        public async Task<ServiceResponse<bool>> EditDepartment(string departmentName, DepartmentDTO updatedDepartment)
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

