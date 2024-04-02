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

        public async Task<List<UserDTO>> GetEmployeesNotAssigned()
        {
            var usersAssignedToTeams = _context.Departments.SelectMany(t => t.Users);
            var unnassignedToTeams = await _context.Users.Where(u => !usersAssignedToTeams.Contains(u)).ToListAsync();

            var userDTOs = unnassignedToTeams.Select(u => new UserDTO(u)).ToList();

            return userDTOs;

        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _context.Users.Select(u => new UserDTO(u)).ToListAsync();
        }
    }
}
