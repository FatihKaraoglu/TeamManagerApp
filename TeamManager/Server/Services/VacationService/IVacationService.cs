namespace TeamManager.Server.Services.VacationService
{
    public interface IVacationService
    {
        Task<bool> CheckExistingVacation(DateTime startDate, DateTime endDate);
        Task<bool> CheckRemainingVacation(DateTime startDate, DateTime dateTime);
        Task<List<VacationRequest>> GetVacationRequests();
    }
}
