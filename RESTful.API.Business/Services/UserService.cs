using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTful.API.Data;
using RESTful.API.Data.Models;
using RESTful.API.Infrastructure.Models;
using RESTful.API.Infrastructure.Services;

namespace RESTful.API.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        #region Public Methods
        async Task<IEnumerable<UserDTO>> IUserService.GetAllUsersAsync(int currentUserId)
        {
            ValidateExecution(currentUserId);

            var users = await _databaseContext.Users.ToListAsync();

            var result = _mapper.Map<List<UserDTO>>(users);

            return result;
        }

        async Task<UserDTO> IUserService.GetUserByIdAsync(int id, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var user = await _databaseContext.Users.FirstOrDefaultAsync(t => t.Id == id);

            var result = _mapper.Map<UserDTO>(user);

            return result;
        }

        async Task<UserDTO> IUserService.GetUserByIdentificationAsync(string identification, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var user = await _databaseContext.Users.FirstOrDefaultAsync(t => t.Identification == identification);

            var result = _mapper.Map<UserDTO>(user);

            return result;
        }

        async Task<UserDTO> IUserService.CreateUserAsync(UserDTO userDTO, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var user = _mapper.Map<User>(userDTO);
            await _databaseContext.Users.AddAsync(user);

            var dbResult = await _databaseContext.Users.FindAsync(user.Id);
            var result = _mapper.Map<UserDTO>(dbResult);

            return result;
        }

        async Task<UserDTO> IUserService.UpdateUserAsync(UserDTO userDTO, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var dbUser = await _databaseContext.Users.FindAsync(userDTO.Id);

            if (dbUser == null)
            {
                throw new KeyNotFoundException();
            }

            dbUser = _mapper.Map<User>(userDTO);

            dbUser.UpdatedBy = currentUserId;

            _databaseContext.Entry(dbUser).State = EntityState.Modified;

            await _databaseContext.SaveChangesAsync();

            var result = _mapper.Map<UserDTO>(dbUser);

            return result;
        }

        async Task<bool> IUserService.DeleteUserAsync(int id, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var dbUser = await _databaseContext.Users.FindAsync(id);

            if (dbUser == null)
            {
                return false;
            }

            dbUser.UpdatedBy = currentUserId;

            await _databaseContext.SaveChangesAsync();

            _databaseContext.Users.Remove(dbUser);

            await _databaseContext.SaveChangesAsync();

            return true;
        }
        #endregion
               
    }
}
