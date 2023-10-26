using RESTful.API.Infrastructure.Services;

namespace RESTful.API.Business.Services
{
    public class BaseService : IBaseService
    {
        public void ValidateExecution(int userId)
        {
            if (userId < 1)
                throw new ArgumentException("User is not set. Not possible to get data.");
        }
    }
}
