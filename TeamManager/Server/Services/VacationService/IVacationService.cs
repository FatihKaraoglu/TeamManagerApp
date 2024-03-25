namespace TeamManager.Server.Services.VacationService
{
    public interface IVacationService
    {
        Task<bool> CheckExistingVacation(DateTime startDate, DateTime endDate, int userId);
        Task<bool> CheckRemainingVacation(DateTime startDate, DateTime dateTime, int userId);
    }
}
