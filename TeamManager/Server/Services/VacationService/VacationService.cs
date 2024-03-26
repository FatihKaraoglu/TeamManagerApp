

namespace TeamManager.Server.Services.VacationService
{
    public class VacationService : IVacationService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public VacationService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<bool> CheckExistingVacation(DateTime startDate, DateTime endDate)
        {
            // Check if there are any existing vacation requests for the same user that overlap with the specified date range
            bool overlapExists = await _context.VacationRequests
                .AnyAsync(vr => vr.UserId == _authService.GetUserId() &&
                                ((startDate >= vr.StartDate && startDate <= vr.EndDate) ||
                                 (endDate >= vr.StartDate && endDate <= vr.EndDate) ||
                                 (vr.StartDate >= startDate && vr.StartDate <= endDate) ||
                                 (vr.EndDate >= startDate && vr.EndDate <= endDate)));

            return overlapExists;
        }

        public async Task<bool> CheckRemainingVacation(DateTime startDate, DateTime endDate)
        {
            // Calculate the total number of days between startDate and endDate
            int totalRequestedDays = (int)(endDate - startDate).TotalDays;

            // Retrieve the VacationBalance for the specified userId and current year
            VacationBalance vacationBalance = await _context.vacationBalances
                .FirstOrDefaultAsync(vb => vb.UserId == _authService.GetUserId() && vb.Year == DateTime.Now.Year);

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

        public async Task<List<VacationRequest>> GetVacationRequests()
        {
            // Query the database to fetch all vacation requests for the given userId
            var vacationRequests = await _context.VacationRequests
                                                .Where(vr => vr.UserId == _authService.GetUserId())
                                                .ToListAsync();

            return vacationRequests;
        }
    }
}
