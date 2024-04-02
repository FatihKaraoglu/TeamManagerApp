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

        public async Task<ServiceResponse<List<UserDTO>>> GetAllUsers()
        {
            var result = await _http.GetAsync("api/user/allUsers");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<List<UserDTO>>>();
            return response;
        }

        public async Task<ServiceResponse<List<UserDTO>>> GetEmployyesUnassigned()
        {
            var result = await _http.GetAsync("api/user/EmployeesNotAssigned");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<List<UserDTO>>>();
            return response;
        }
    }
}
