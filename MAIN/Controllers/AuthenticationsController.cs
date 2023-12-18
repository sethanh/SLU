using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SERVICE.Dtos.Authentications;
using DATA.EF_CORE;
using System;
using DATA.Enums;
using Microsoft.AspNetCore.Authorization;

namespace MAIN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationsController : MainControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IConfiguration _config;        

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

            AuthenticateResponse authResponse;
            try
            {
                authResponse = _authenticationService.GetAuthResponse(
                    model
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }
            
            return Ok(authResponse);
        }

        [Authorize]
        [HttpPost("Register")]
        public IActionResult UserRegister(UserRegisterRequest userRegister)
        {
            try
            {
                _authenticationService.RegisterUser(
                    userRegister,
                    CurrentShopId,
                    CurrentShopBranchId
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            var result = new UserRegisterResponse
            {
                Message = SUCCESS_MESSAGE.CREATE_USER_SUCCESS
            };
            return Ok(result);
        }
    }
}
