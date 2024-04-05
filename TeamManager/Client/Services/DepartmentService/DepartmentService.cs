
using System.Net.Http;
using TeamManager.Shared.DTO;

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


        public async Task<ServiceResponse<bool>> AddDepartment(DepartmentDTO department)
        {
            try
            {
                // Send POST request to the specified endpoint with DepartmentDTO as JSON payload
                var result = await _http.PostAsJsonAsync("api/department", department);

                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

                // Check if the response is successful
                if (response.Success)
                {
                    // Deserialize response content into ServiceResponse<bool>
                    return response;
                }
                else
                {
                    // Handle unsuccessful response (e.g., non-2xx status code)
                    // You might want to handle different error cases here
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Failed to add department",
                        Data = false // or default value for bool
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = false // or default value for bool
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteDepartment(int departmentId)
        {
            try
            {
                // Send DELETE request to the specified endpoint with departmentId as part of the URL
                var result = await _http.DeleteAsync($"api/department/{departmentId}");

                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

                // Check if the response is successful
                if (response.Success)
                {
                    // Deserialize response content into ServiceResponse<bool>
                    return response;
                }
                else
                {
                    // Handle unsuccessful response (e.g., non-2xx status code)
                    // You might want to handle different error cases here
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Failed to delete department",
                        Data = false // or default value for bool
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = false // or default value for bool
                };
            }
        }
    }
}

