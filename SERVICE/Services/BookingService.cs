using DATA.EF_CORE;
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
        public BookingService(BookingManager domainService) : base(domainService)
        {
        }

        public Booking CreateBooking(BookingDto model, string bookingFrom)
        {
            var bookingDetailDtos = model.BookingDetails;
            var bookingDetails = new List<BookingDetail>();

            foreach (var bookingDetailDto in bookingDetailDtos)
            {
                var bookingDetailServiceDtos = bookingDetailDto.BookingDetailServices;
                var bookingDetailServices = new List<BookingDetailService>();

                foreach (var bookingDetailServiceDto in bookingDetailServiceDtos) 
                {
                    bookingDetailServices.Add(
                        new BookingDetailService
                        {
                            ServiceId = bookingDetailServiceDto.ServiceId ?? 0,
                        }
                    );

                }

                bookingDetails.Add(
                    new BookingDetail
                    {
                        Note = bookingDetailDto.Note,
                        ShopId = model.ShopId,
                        ShopBranchId = model.ShopBranchId,
                        BookingDetailServices = bookingDetailServices
                    }
                );
            }

            var booking = new Booking
            {
                BookingFrom = bookingFrom,
                BookingStatus = model.BookingStatus,
                Date = model.Date ?? DateTime.Now,
                Code = model.Code,
                Note = model.Note,
                ShopId = model.ShopId,
                ShopBranchId = model.ShopBranchId,
                BookingDetails = bookingDetails,
                CustomerId = model.CustomerId ?? 0
            };

            Add(booking);
            return booking;
        }
    }
}
