using RESTful.API.Infrastructure.Models;

namespace RESTful.API.Infrastructure.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypeDTO>> GetAllUserTypesAsync(int currentUserId);
        Task<UserTypeDTO> GetUserTypeByIdAsync(int id, int currentUserId);
        Task<UserTypeDTO> CreateUserTypeAsync(UserTypeDTO userType, int currentUserId);
        Task<UserTypeDTO> UpdateUserTypeAsync(UserTypeDTO userType, int currentUserId);
        Task<bool> DeleteUserTypeAsync(int id, int currentUserId);
    }
}
