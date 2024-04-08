using TeamManager.Shared.DTO;

namespace TeamManager.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> GetUser();
        public Task<List<UserDTO>> GetEmployeesNotAssigned();
        public Task<bool> AddUserToDepartment(int userId, int departmentId);
        public Task<ServiceResponse<bool>> UpdateProfile(ProfileForm profileForm);
    }
}
