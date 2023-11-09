using DATA.EF_CORE;
using SERVICE.Dtos.BookingDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Bookings
{
    public class BookingDto
    {
        public long? Id { get; set; }
        public int? Quantity { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public string Code { get; set; }
        public string BookingStatus { get; set; }
        public string BookingFrom { get; set; }
        public string Note { get; set; }
        public long? ShopId { get; set; }
        public long? ShopBranchId { get; set; }
        public List<BookingDetailDto> BookingDetails { get; set; }

        public static BookingDto Create(Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                Quantity = booking.Quantity,
                CustomerId = booking.CustomerId,
                Date = booking.Date,
                Code = booking.Code,
                BookingStatus = booking.BookingStatus,
                BookingFrom = booking.BookingFrom,
                Note = booking.Note,
                ShopId = booking.ShopId,
                ShopBranchId = booking.ShopBranchId,
                BookingDetails = booking.BookingDetails != null 
                    ? BookingDetailDto.Create(booking.BookingDetails.ToList()) 
                    : null
            };
        } 
    }
}
