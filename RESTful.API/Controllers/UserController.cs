using Microsoft.AspNetCore.Mvc;
using RESTful.API.Infrastructure.Services;

namespace RESTful.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsersAsync(1);

            if(users == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No users in the database.");
            }

            return StatusCode(StatusCodes.Status200OK , users);
        }
    }
}