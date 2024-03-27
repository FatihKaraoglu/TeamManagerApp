
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

        public async Task<ServiceResponse<VacationBalance>> GetVacationBalance()
        {
            var requestDto = new VacationBalanceRequestDTO { Year = DateTime.Now.Year };
            var result = await _http.PostAsJsonAsync("api/vacation/VacationBalance", requestDto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<VacationBalance>>();
        }

        public async Task<ServiceResponse<List<VacationRequest>>> GetVacationRequests()
        {
            var result = await _http.GetAsync("api/vacation/VacationRequests");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<List<VacationRequest>>>();
            return response;
        }

        public async Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/vacation/RequestVacation", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
