using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : MainControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;

        public UsersController(
            UserService userService,
            IConfiguration config
        )
        {
            _userService = userService;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll().AsNoTracking();

            return OkList(users);
        }
    }
}
