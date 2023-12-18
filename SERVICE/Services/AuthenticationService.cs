using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DATA.EF_CORE;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SERVICE.Helpers;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class AuthenticationService : ApplicationService<User>
    {
        private readonly IConfiguration _config;
        public AuthenticationService(
            IConfiguration config,
            UserManager domainService
            ) : base(domainService)
        {
            _config = config;
        }

        public string GetJwtKeyString()
        {
            return _config["Jwt:Key"];
        }

        public string GetJwtIssuer()
        {
            return _config["Jwt:Issuer"];
        }

        public string GetJwtSecurityToken(
            User user,
            string jwtKeyString,
            string jwtIssuer
            )
        {
            var token = AuthenticationHelper.GetJwtSecurityToken(
                user,
                jwtKeyString,
                jwtIssuer
            );

            return token;
        }
    }
}
