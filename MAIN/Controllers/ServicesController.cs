using Microsoft.AspNetCore.Mvc;
using SERVICE.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SERVICE.Dtos.Customers;
using DATA.Enums;
using System;
using DATA.EF_CORE;
using SERVICE.Dtos.Bookings;
using SERVICE.Dtos.Services;

namespace MAIN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : MainControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(
            ServiceService serviceService
        )
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] ServiceDto model)
        {
            model.ShopId = CurrentShopId;
            model.ShopBranchId = CurrentShopBranchId;

            var newService = _serviceService.CreateService(
                model, 
                CurrentUserEmail
            );

            return Ok(ServiceDto.Create(newService));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] long id)
        {
            var service = _serviceService.GetAll().FirstOrDefault(c => c.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(ServiceDto.Create(service));
        }
    }
}
