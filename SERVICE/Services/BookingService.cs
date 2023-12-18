using DATA.EF_CORE;
using DATA.Enums;
using SERVICE.Dtos.Bookings;
using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class BookingService : ApplicationService<Booking>
    {
        private readonly CustomerManager _customerManager;
        private readonly BookingManager _bookingManager;
        public BookingService(
            BookingManager domainService,
            CustomerManager customerManager,
            BookingManager bookingManager
            ) : base(domainService)
        {
            _customerManager = customerManager;
            _bookingManager = bookingManager;
        }

        public Booking CreateBookingFromCustomerApp(
            BookingDto model, 
            long CurrentCustomerAccountId,
            string createBy
            )
        {
            var customer = _customerManager.GetAll()
                .FirstOrDefault(c => c.ShopId == model.ShopId && c.CustomerAccountId == CurrentCustomerAccountId); 
            if (customer == null)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.NOT_EXIST_CUSTOMER);
            }

            model.CustomerId = customer.Id;

            var newBooking = _bookingManager.CreateBooking(
                model,
                BOOKING_FROM.CUSTOMER_APP,
                createBy
            );

            return newBooking;
        }

        public Booking CreateBookingFromMain(
            BookingDto model, 
            long CurrentShopId,
            long CurrentShopBranchId,
            string createBy
            )
        {
            model.ShopId = CurrentShopId;
            model.ShopBranchId = CurrentShopBranchId;

            var newBooking = _bookingManager.CreateBooking(
                model, 
                BOOKING_FROM.MAIN_APP,
                createBy
            );

            return newBooking;
        }
    }
}
