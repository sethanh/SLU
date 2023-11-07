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

namespace MAIN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : MainControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(
            CustomerService customerService
        )
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto model)
        {
            var newCustomer = _customerService.CreateCustomer(model, CurrentShopId);

            return Ok(CustomerDto.CopyValueFromEntity(newCustomer));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] long id)
        {
            var customer = _customerService.GetAll().FirstOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(CustomerDto.CopyValueFromEntity(customer));
        }

        [HttpGet]
        public IActionResult GetAllCustomer([FromQuery] string customerMobile = null)
        {
            var customers = _customerService.GetAll().Where(c => c.ShopId == CurrentShopId).ToList();

            if (customerMobile != null)
            {
                customers = customers.Where(c => c.Mobile == customerMobile).ToList();
            }

            return Ok(CustomerDto.CopyValueFromEntity(customers));
        }
    }
}
