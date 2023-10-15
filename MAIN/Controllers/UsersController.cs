using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using MAIN.Dtos.Users;
using DATA.Enums;
using Microsoft.IdentityModel.Tokens;
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
        private const int minLengthPassword = 6;

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
            var lengthPassword = model.Password.Length;

            if (lengthPassword < minLengthPassword)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.PASSWORD_IS_NOT_VALID);
            }

            var newUser = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                UserGroupId = model.UserGroupId,
                ShopId = CurrentShopId,
                ShopBranchId = CurrentShopBranchId
            };

            _userService.Add(newUser);

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

        // [HttpGet("{userId}")]
        // public IActionResult GetByUserId([FromRoute] long userId)
        // {
        //     var user = _userService.GetAll().AsNoTracking()
        //         .FirstOrDefault(u => u.Id == userId);
            
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(UserDto.Create(user));
        // }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromBody] UserDto model, [FromRoute] long userId)
        {
            var user = _userService.GetAll().AsNoTracking()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = model.Name ?? user.Name;
            user.Email = model.Email ?? user.Email;
            user.Password = model.Password != SECURITY_VALUE.PASSWORD ? model.Password : user.Password;
            user.UserGroupId = model.UserGroupId ?? user.UserGroupId;
            user.Updated = DateTime.Now;
            user.UpdatedBy = CurrentUserEmail;     

            _userService.Update( user );

            return Ok(UserDto.Create(user));
        }
    }
}
