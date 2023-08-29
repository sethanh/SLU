using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using DATA.EF_CORE;
using Microsoft.EntityFrameworkCore;
using SERVICE.Services;

namespace MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : MainControllerBase
    {
        private readonly UserServices _userServices;

        public UsersController(
            UserServices userServices
        )
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userServices.GetAll().AsNoTracking();

            return OkList(users);
        }
    }
}
