using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<List<UserDTO>> GetEmployeesNotAssigned();
    }
}
