using Microsoft.AspNetCore.Mvc;
using RESTful.API.Infrastructure.Models;
using RESTful.API.Infrastructure.Services;

namespace RESTful.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IUserTypeService _userTypeService;

        public UserController(ILogger<UserController> logger, 
            IUserService userService, 
            IUserTypeService userTypeService)
        {
            _logger = logger;
            _userService = userService;
            _userTypeService = userTypeService;
        }

        #region Users
        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync(1);

            if (users == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No users in the database.");
            }

            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            var userCreated = await _userService.CreateUserAsync(user, 1);

            if (userCreated == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User not created, check with the API admin.");
            }

            return base.StatusCode(StatusCodes.Status200OK, userCreated);
        }
        #endregion

        #region User Type

        [HttpGet(Name = "GetUserTypes")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            var userTypes = await _userTypeService.GetAllUserTypesAsync(1);

            if (userTypes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No user types in the database.");
            }

            return StatusCode(StatusCodes.Status200OK, userTypes);
        }

        #endregion
    }
}