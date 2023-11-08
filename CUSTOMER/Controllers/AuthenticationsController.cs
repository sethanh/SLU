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

namespace CUSTOMER.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationsController : CustomerControllerBase
    {
        private readonly CustomerAccountService _customerAccountService;
        private readonly IConfiguration _config;
        private const int minLengthPassword = 6;

        public AuthenticationsController(
            CustomerAccountService customerAccountService,
            IConfiguration config
        )
        {
            _customerAccountService = customerAccountService;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(CustomerAuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(BAD_REQUEST_MESSAGE.MODEL_IS_NOT_VALID);
            }

            var customerAccount = _customerAccountService.GetAll()
            .FirstOrDefault(u => u.Mobile == model.Mobile && u.Password == model.Password);

            if (customerAccount == null)
            {
                return NotFound();
            }

            string jwtKeyString = _config["Jwt:Key"];
            string jwtIssuer = _config["Jwt:Issuer"];

            var token = _customerAccountService.GetJwtSecurityToken(
                customerAccount,
                jwtKeyString,
                jwtIssuer
            );

            var result = CustomerAuthenticateResponse.Create(customerAccount, token);
            return Ok(result);
        }
    }
}
