using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTful.API.Data;
using RESTful.API.Data.Models;
using RESTful.API.Infrastructure.Models;
using RESTful.API.Infrastructure.Services;

namespace RESTful.API.Business.Services
{
    public class UserTypeService : BaseService, IUserTypeService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserTypeService(DatabaseContext databaseContext, IMapper mapper) 
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        async Task<IEnumerable<UserTypeDTO>> IUserTypeService.GetAllUserTypesAsync(int currentUserId)
        {
            ValidateExecution(currentUserId);

            var userTypes = await _databaseContext.UserTypes.ToListAsync();

            var result = _mapper.Map<List<UserTypeDTO>>(userTypes);

            return result;
        }

        async Task<UserTypeDTO> IUserTypeService.GetUserTypeByIdAsync(int id, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var userType = await _databaseContext.UserTypes.FirstOrDefaultAsync(t => t.Id == id);

            var result = _mapper.Map<UserTypeDTO>(userType);

            return result;
        }

        async Task<UserTypeDTO> IUserTypeService.CreateUserTypeAsync(UserTypeDTO userTypeDTO, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var userType = _mapper.Map<UserType>(userTypeDTO);
            await _databaseContext.UserTypes.AddAsync(userType);
            
            var dbResult = await _databaseContext.UserTypes.FindAsync(userType.Id);
            var result = _mapper.Map<UserTypeDTO>(dbResult);
            
            return result;
        }        

        async Task<UserTypeDTO> IUserTypeService.UpdateUserTypeAsync(UserTypeDTO userTypeDTO, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var dbUserType = await _databaseContext.UserTypes.FindAsync(userTypeDTO.Id);

            if (dbUserType == null)
            {
                throw new KeyNotFoundException();
            }

            dbUserType = _mapper.Map<UserType>(userTypeDTO);
            
            dbUserType.UpdatedBy = currentUserId;

            _databaseContext.Entry(dbUserType).State = EntityState.Modified;            

            await _databaseContext.SaveChangesAsync();

            var result = _mapper.Map<UserTypeDTO>(dbUserType);

            return result;
        }

        async Task<bool> IUserTypeService.DeleteUserTypeAsync(int id, int currentUserId)
        {
            ValidateExecution(currentUserId);

            var dbUserType = await _databaseContext.UserTypes.FindAsync(id);

            if (dbUserType == null)
            {
                return false;
            }

            dbUserType.UpdatedBy = currentUserId;

            await _databaseContext.SaveChangesAsync();

            _databaseContext.UserTypes.Remove(dbUserType);

            await _databaseContext.SaveChangesAsync();

            return true;
        }
    }
}
