

using Microsoft.EntityFrameworkCore;
using TeamManager.Shared.DTO;

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
            VacationBalance vacationBalance = await _context.VacationBalances
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

        public async Task<ServiceResponse<VacationBalance>> GetVacationBalance(int year)
        {
            try
            {
                int id = _authService.GetUserId();
                var balance = await _context.VacationBalances
                    .FirstOrDefaultAsync(vb => vb.UserId == _authService.GetUserId());

                if (balance != null)
                {
                    return new ServiceResponse<VacationBalance>
                    {
                        Success = true,
                        Data = balance
                    };
                }
                else
                {
                    return new ServiceResponse<VacationBalance>
                    {
                        Success = false,
                        Message = "Vacation balance not found for the given user ID and year."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<VacationBalance>
                {
                    Success = false,
                    Message = "Could not retrieve your Vacation Balance. Error: " + ex.Message
                };
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

        public async Task<ServiceResponse<bool>> RequestVacation(VacationRequestDTO requestDTO)
        {
            try
            {
                // Check remaining vacation days
                if (!await CheckRemainingVacation(requestDTO.StartDate, requestDTO.EndDate))
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "You don't have enough Vacation Days left!"
                    };
                }

                // Check existing vacation requests for the time period
                if (await CheckExistingVacation(requestDTO.StartDate, requestDTO.EndDate))
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "You already have requested Vacation for this time period!"
                    };
                }

                // Map DTO to entity
                var vacationRequest = new VacationRequest
                {
                    UserId = _authService.GetUserId(),
                    StartDate = requestDTO.StartDate,
                    EndDate = requestDTO.EndDate,
                    Reason = requestDTO.Reason,
                    Status = "Waiting for approval"
                    // Map other properties from DTO to entity as needed
                };

                // Add the new vacation request to DbContext
                _context.VacationRequests.Add(vacationRequest);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool>
                {
                    Success = true,
                    Message = "Vacation request submitted successfully."
                };
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "An error occurred while processing your request: " + ex.Message
                };
            }


        }
    }
}
