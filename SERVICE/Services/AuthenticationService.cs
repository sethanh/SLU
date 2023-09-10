using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DATA.EF_CORE;
using Microsoft.IdentityModel.Tokens;
using SERVICE.Helpers;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class AuthenticationService : ApplicationService<User>
    {
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
            var token = AuthenticationHelper.GetJwtSecurityToken(
                user,
                jwtKeyString,
                jwtIssuer
            );

            return token;
        }
    }
}
