
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.VacationService
{
    public interface IVacationService
    {
        Task<bool> CheckExistingVacation(DateTime startDate, DateTime endDate);
        Task<bool> CheckRemainingVacation(DateTime startDate, DateTime dateTime);
        Task<List<VacationRequest>> GetVacationRequests();
        Task<ServiceResponse<VacationBalance>> GetVacationBalance(int year);
        Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO requestDTO);

    }
}
