using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DATA.EF_CORE;
using Microsoft.IdentityModel.Tokens;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class AuthenticationService : ApplicationService<User>
    {

        private const int expiredDate = 180;
        public AuthenticationService(
            UserManager domainService
            ) : base(domainService)
        {

        }

        public string GetJwtSecurityToken(
            User user,
            string jwtKeyString,
            string jwtIssuer
            )
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new("UserId", user.Id.ToString()),
                new("Name", user.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKeyString));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtIssuer,
                claims: claims,
                expires: DateTime.Now.AddDays(expiredDate),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
