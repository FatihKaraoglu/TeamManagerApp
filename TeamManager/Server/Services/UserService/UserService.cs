using Microsoft.EntityFrameworkCore;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<bool> AddUserToDepartment(int userId, int departmentId)
        {
            var userToUpdate = await _context.Users.FindAsync(userId);

            if (userToUpdate == null)
            {
                throw new Exception("No user with this Id found!");
                return false;
            } else
            {
                try
                {
                    userToUpdate.DepartmentId = departmentId;
                    await _context.SaveChangesAsync();
                    return true;
                } catch (Exception ex)
                {
                    throw new Exception("Failed to add User to Department!");
                    return false;
                }
                
            }
        }

        public async Task<List<UserDTO>> GetEmployeesNotAssigned()
        {
            var usersWithoutDepartment = await _context.Users
            .Where(u => u.DepartmentId == null)
            .ToListAsync();

            var userDTOs = usersWithoutDepartment.Select(u => new UserDTO(u)).ToList();

            return userDTOs;

        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.Department)
                .Include(u => u.Address)
                .Select(u => new UserDTO(u)).ToListAsync();
        }

        public async Task<UserDTO> GetUser()
        {
            var userId = _authService.GetUserId();

            var user = await _context.Users
                .Include(u => u.Address) // Include the Address navigation property
                .FirstOrDefaultAsync(u => u.Id == userId);

            var dto = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber
            };

            if (user.Address != null)
            {
                // Populate address fields in the UserDTO
                dto.Adress = new Address
                {
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode
                };
            }
            else
            {
                // Handle case where user's address is not available (optional)
                dto.Adress = new Address(); // Create an empty AddressDTO
            }

            return dto;
        }

        public async Task<ServiceResponse<bool>> UpdateProfile(ProfileForm profileForm)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Address).Where(u => u.Id == _authService.GetUserId()).FirstAsync();

                user.PhoneNumber = profileForm.PhoneNumber;
                user.FirstName = profileForm.FirstName;
                user.LastName = profileForm.LastName;
                user.Email = profileForm.Email;
                user.Address.State = profileForm.State;
                user.Address.City = profileForm.City;
                user.Address.ZipCode = profileForm.ZipCode;
                user.Address.Street = profileForm.Street;

                await _context.SaveChangesAsync();
                return new ServiceResponse<bool> { Success = true };
            } catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Failed to update User Profile"
                };
            }
        }
    }
}
