using TeamManager.Shared.DTO;

namespace TeamManager.Client.Services.VacationService
{
    public interface IVacationService
    {
        Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO request);
    }
}
