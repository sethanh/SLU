using DATA.EF_CORE;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SERVICE.Helpers
{
    public static class AuthenticationHelper
    {
        private const int expiredDate = 180;

        public static string GetJwtSecurityToken(
            User user,
            string jwtKeyString,
            string jwtIssuer
            )
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new("UserId", user.Id.ToString()),
                new("ShopId", user.ShopId.ToString()),
                new("ShopBranchId", user.ShopBranchId.ToString()),
                new("Email", user.Email.ToString()),
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

        public static string GetCustomerJwtSecurityToken(
            CustomerAccount customerAccount,
            string jwtKeyString,
            string jwtIssuer
            )
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, customerAccount.Id.ToString()),
                new("Mobile", customerAccount.Mobile),
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
