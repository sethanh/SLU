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
using SERVICE.Managers;

namespace CUSTOMER.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationsController : CustomerControllerBase
    {
        private readonly CustomerAccountService _customerAccountService;
        private const int minLengthPassword = 6;

        public AuthenticationsController(
            CustomerAccountService customerAccountService
        )
        {
            _customerAccountService = customerAccountService;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(CustomerAuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.MODEL_IS_NOT_VALID);
            }

            CustomerAuthenticateResponse? authResponse;

            try
            {
                authResponse = _customerAccountService.GetAuthResponse(
                    model
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            return Ok(authResponse);
        }

        [HttpPost("Register")]
        public IActionResult UserRegister(CustomerAccountRegister customerRegister)
        {
            CustomerAuthenticateResponse? authResponse;

            try
            {
                authResponse = _customerAccountService.RegisterCustomerAccount(
                    customerRegister
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            return Ok(authResponse);
        }
    }
}
