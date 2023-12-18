using DATA.EF_CORE;
using DATA;
using SERVICE.Dtos.Bookings;
using System.Collections.Generic;
using System;

namespace SERVICE.Managers
{
    public class BookingManager : DomainService<Booking>
    {
        public BookingManager(UnitOfWork unitOfWork) : base(unitOfWork) { }

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

            Add(booking, saveChange: true);
            return booking;
        }

    }
}
