using TeamManager.Shared.DTO;
using static System.Net.WebRequestMethods;

namespace TeamManager.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<bool>> AddUserToDepartment(int userId, int departmentId)
        {
            var parameters = new EmployeeToDepartmentDTO()
            {
                DepartmentId = departmentId,
                EmployeeId = userId
            };
            var result = await _http.PostAsJsonAsync("api/user/AddEmployeeToDepartment", parameters);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return response;
        }

        public async Task<ServiceResponse<List<UserDTO>>> GetAllUsers()
        {
            var result = await _http.GetAsync("api/user/allUsers");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<List<UserDTO>>>();
            return response;
        }
    }
}
