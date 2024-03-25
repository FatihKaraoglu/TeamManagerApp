
namespace TeamManager.Server.Services.VacationService
{
    public class VacationService : IVacationService
    {
        private readonly DataContext _context;
        public VacationService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckExistingVacation(DateTime startDate, DateTime endDate, int userId)
        {
            // Check if there are any existing vacation requests for the same user that overlap with the specified date range
            bool overlapExists = await _context.VacationRequests
                .AnyAsync(vr => vr.UserId == userId &&
                                ((startDate >= vr.StartDate && startDate <= vr.EndDate) ||
                                 (endDate >= vr.StartDate && endDate <= vr.EndDate) ||
                                 (vr.StartDate >= startDate && vr.StartDate <= endDate) ||
                                 (vr.EndDate >= startDate && vr.EndDate <= endDate)));

            return overlapExists;
        }

        public async Task<bool> CheckRemainingVacation(DateTime startDate, DateTime endDate, int userId)
        {
            // Calculate the total number of days between startDate and endDate
            int totalRequestedDays = (int)(endDate - startDate).TotalDays;

            // Retrieve the VacationBalance for the specified userId and current year
            VacationBalance vacationBalance = await _context.vacationBalances
                .FirstOrDefaultAsync(vb => vb.UserId == userId && vb.Year == DateTime.Now.Year);

            if (vacationBalance != null)
            {
                // Check if the remaining balance is sufficient to cover for the requested days
                return vacationBalance.RemainingBalance >= totalRequestedDays;
            }
            else
            {
                // If no VacationBalance found, assume there's not enough balance
                return false;
            }
        }
    }
}
