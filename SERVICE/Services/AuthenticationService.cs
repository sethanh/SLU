using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DATA.EF_CORE;
using DATA.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SERVICE.Dtos.Authentications;
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
        
        public AuthenticateResponse GetAuthResponse(
            AuthenticateRequest model
            )
        {
            var user = GetAll().FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                throw new Exception(EXCEPTION_TYPE.NOT_FOUND);
            }

            var token = AuthenticationHelper.GetJwtSecurityToken(
                user,
                GetJwtKeyString(),
                GetJwtIssuer()
            );

            var authResponse = AuthenticateResponse.Create(user, token);
            return authResponse;
        }

        public User RegisterUser(
            UserRegisterRequest userRegister,
            long CurrentShopId,
            long CurrentShopBranchId
            )
        {
            var user = GetAll().FirstOrDefault(u => u.Email == userRegister.Email);

            if (user != null)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.EXISTED_USER);
            }

            var lengthPassword = userRegister.Password.Length;

            if (lengthPassword < SECURITY_VALUE.MIN_LENGTH)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.PASSWORD_IS_NOT_VALID);
            }

            var newUser = new User
            {
                Email = userRegister.Email,
                Name =  userRegister.Name,
                Password = userRegister.Password,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                ShopBranchId = CurrentShopBranchId,
                ShopId = CurrentShopId
            };

            Add(newUser);

            return newUser;
        }
    }
}
