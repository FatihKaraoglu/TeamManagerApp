using TeamManager.Shared.DTO;

namespace TeamManager.Client.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<List<UserDTO>>> GetAllUsers();

    }
}
