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

namespace MAIN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : MainControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingsController(
            BookingService bookingService
        )
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingDto model)
        {
            var newBooking = _bookingService.CreateBooking(model, BOOKING_FROM.CUSTOMER_APP);

            return Ok(newBooking);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] long id)
        {
            var booking = _bookingService.GetAll().FirstOrDefault(c => c.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
    }
}
