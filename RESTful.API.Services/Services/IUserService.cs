using RESTful.API.Infrastructure.Models;

namespace RESTful.API.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync(int currentUserId);
        Task<UserDTO> GetUserByIdAsync(int id, int currentUserId);
        Task<UserDTO> GetUserByIdentificationAsync(string identification, int currentUserId);
        Task<UserDTO> CreateUserAsync(UserDTO user, int currentUserId);
        Task<UserDTO> UpdateUserAsync(UserDTO user, int currentUserId);
        Task<bool> DeleteUserAsync(int id, int currentUserId);
    }
}
