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

namespace CUSTOMER.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : CustomerControllerBase
    {
        private readonly BookingService _bookingService;
        private readonly CustomerService _customerService;

        public BookingsController(
            BookingService bookingService,
            CustomerService customerService
        )
        {
            _bookingService = bookingService;
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingDto model)
        {
            Booking newBooking;
            try
            {
                newBooking = _bookingService.CreateBookingFromCustomerApp(
                    model,
                    CurrentCustomerAccountId,
                    CurrentMobile
                );
            }
            catch (Exception exception)
            {
                return OKException(exception);
            }

            var bookingResult = _bookingService.GetAll()
                .Where(b => b.Id == newBooking.Id)
                .Include(b => b.BookingDetails)
                    .ThenInclude(b => b.BookingDetailObjects)
                        .ThenInclude(b => b.Service)
                .FirstOrDefault();

            return Ok(BookingDto.Create(bookingResult));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] long id)
        {
            var booking = _bookingService.GetAll()
                .Where(b => b.Id == id)
                .Include(b => b.BookingDetails)
                    .ThenInclude(b => b.BookingDetailObjects)
                        .ThenInclude(b => b.Service)
                .FirstOrDefault();

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(BookingDto.Create(booking));
        }
    }
}
