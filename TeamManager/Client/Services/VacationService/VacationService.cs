
using TeamManager.Shared.DTO;
using static System.Net.WebRequestMethods;

namespace TeamManager.Client.Services.VacationService
{
    public class VacationService : IVacationService
    {
        private readonly HttpClient _http;
        public VacationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/vacation", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
