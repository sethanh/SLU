using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SERVICE.Dtos.Users;
using DATA.Enums;
using System;
using DATA.EF_CORE;

namespace MAIN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto model)
        {
            User newUser;
            try
            {
                newUser = _userService.CreateUser(
                    model,
                    CurrentShopId,
                    CurrentShopBranchId
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            return Ok(UserDto.Create(newUser));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll().AsNoTracking()
                .Where(u => u.ShopId == CurrentShopId && u.ShopBranchId == u.ShopBranchId)
                .ToList();

            return OkList(UserDto.Create(users));
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId([FromRoute] long userId)
        {
            var user = _userService.GetAll().AsNoTracking()
                .FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(UserDto.Create(user));
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromBody] UserDto model, [FromRoute] long userId)
        {
            User user;
            try
            {
                user = _userService.UpdateUser(
                    model,
                    userId,
                    CurrentUserEmail
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            return Ok(UserDto.Create(user));
        }
    }
}
