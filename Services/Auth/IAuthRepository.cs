

using ChatHub.Models.Users;

namespace PhotoGallery_BackEnd.Services.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<string>> ResetPassword(string username, string password);

        Task<ServiceResponse<List<UserDto>>> GetAllUser();

        Task<ServiceResponse<List<UserDto>>> DeleteUser(string username);

        Task<ServiceResponse<List<UserDto>>> UpdateUser(string username, string accessLevelName);

        Task<bool> UserExists(string username);
    }
}
