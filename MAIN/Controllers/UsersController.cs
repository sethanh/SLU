using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MAIN.Dtos.Authentications;
using Microsoft.AspNetCore.Authorization;
using DATA.EF_CORE;
using System.Text;

namespace MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : MainControllerBase
    {
        private readonly UserServices _userServices;
        private readonly IConfiguration _config;

        public UsersController(
            UserServices userServices,
            IConfiguration config
        )
        {
            _userServices = userServices;
            _config = config;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var user = _userServices.GetAll().AsNoTracking()
                    .FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);

            if(user == null)
            {
                return NotFound();
            }

            var token = GetJwtSecurityToken(user);

            var result = new AuthenticateResponse(user, token);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userServices.GetAll().AsNoTracking();

            return OkList(users);
        }

        private string GetJwtSecurityToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("Name", user.Name)
            };

            var keyString = _config["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(keyString));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(180),
                signingCredentials: creds
            );

           return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
