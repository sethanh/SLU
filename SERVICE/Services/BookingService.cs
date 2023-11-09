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

        public Booking CreateBooking(
            BookingDto model, 
            string bookingFrom,
            string createBy
            )
        {
            var bookingDetailDtos = model.BookingDetails;
            var bookingDetails = new List<BookingDetail>();

            foreach (var bookingDetailDto in bookingDetailDtos)
            {
                var BookingDetailObjectDtos = bookingDetailDto.BookingDetailObjects;
                var BookingDetailObjects = new List<BookingDetailObject>();

                foreach (var BookingDetailObjectDto in BookingDetailObjectDtos) 
                {
                    BookingDetailObjects.Add(
                        new BookingDetailObject
                        {
                            ServiceId = BookingDetailObjectDto.ServiceId ?? 0,
                        }
                    );

                }

                bookingDetails.Add(
                    new BookingDetail
                    {
                        Note = bookingDetailDto.Note,
                        ShopId = model.ShopId,
                        ShopBranchId = model.ShopBranchId,
                        BookingDetailObjects = BookingDetailObjects
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
                CustomerId = model.CustomerId ?? 0,
                CreatedBy = createBy
            };

            Add(booking);
            return booking;
        }
    }
}
