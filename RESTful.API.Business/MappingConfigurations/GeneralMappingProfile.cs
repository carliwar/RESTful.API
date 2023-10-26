using AutoMapper;
using RESTful.API.Data.Models;
using RESTful.API.Infrastructure.Models;

namespace RESTful.API.Business.MappingConfigurations
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserType, UserTypeDTO>();
        }
    }
}
