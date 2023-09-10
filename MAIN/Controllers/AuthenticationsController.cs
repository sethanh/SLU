using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MAIN.Dtos.Authentications;
using DATA.EF_CORE;
using System;
using DATA.Enums;


namespace MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : MainControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IConfiguration _config;
        private const int minLengthPassword = 6;

        public AuthenticationsController(
            AuthenticationService userServices,
            IConfiguration config
        )
        {
            _authenticationService = userServices;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.MODEL_IS_NOT_VALID);
            }

            var user = _authenticationService.GetAll().AsNoTracking()
            .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                return NotFound();
            }

            string jwtKeyString = _config["Jwt:Key"];
            string jwtIssuer = _config["Jwt:Issuer"];

            var token = _authenticationService.GetJwtSecurityToken(
                user,
                jwtKeyString,
                jwtIssuer
            );

            var result = new AuthenticateResponse(user, token);
            return Ok(result);
        }

        [HttpPost("Register")]
        public IActionResult UserRegister(UserRegisterRequest userRegister)
        {
            var user = _authenticationService.GetAll().AsNoTracking()
                .FirstOrDefault(u => u.Email == userRegister.Email);

            if (user != null)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.EXISTED_USER);
            }

            var lengthPassword = userRegister.Password.Count();

            if (lengthPassword < minLengthPassword)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.PASSWORD_IS_NOT_VALID);
            }

            var newUser = new User
            {
                Email = userRegister.Email,
                Name =  userRegister.Name,
                Password = userRegister.Password,
                SecurityStamp = DateTime.Now.ToString(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Status = STATUS.ENABLE
            };

           _authenticationService.Add(newUser);

            var result = new UserRegisterResponse
            {
                Message = SUCCESS_MESSAGE.CREATE_USER_SUCCESS
            };
            return Ok(result);
        }
    }
}
