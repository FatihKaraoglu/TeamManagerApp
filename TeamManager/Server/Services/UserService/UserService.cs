using Microsoft.EntityFrameworkCore;
using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
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
                .Select(u => new UserDTO(u)).ToListAsync();
        }
    }
}
