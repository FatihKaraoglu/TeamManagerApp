
namespace TeamManager.Client.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;
        public DepartmentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<List<Department>>> GetDepartments()
        {
            var result = await _http.GetAsync("api/department");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<List<Department>>>();
            return response;
        }
    }
}
