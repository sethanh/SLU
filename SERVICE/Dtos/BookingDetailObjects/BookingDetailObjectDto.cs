using DATA.EF_CORE;
using SERVICE.Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.BookingDetailObjects
{
    public class BookingDetailObjectDto
    {
        public long? Id { get; set; }
        public long? BookingId { get; set; }
        public long? BookingDetailId { get; set; }
        public long? ServiceId { get; set; }
        public ServiceDto Service { get; set; }

        public static BookingDetailObjectDto Create(BookingDetailObject bookingDetailObject)
        {
            return new BookingDetailObjectDto
            {
                Id = bookingDetailObject.Id,
                BookingDetailId = bookingDetailObject.BookingDetailId,
                BookingId = bookingDetailObject.BookingId,
                ServiceId = bookingDetailObject.ServiceId,
                Service = bookingDetailObject.Service != null
                    ? ServiceDto.Create(bookingDetailObject.Service)
                    : null
            };
        }

        public static List<BookingDetailObjectDto> Create(List<BookingDetailObject> bookingDetailObjects)
        {
            var result = bookingDetailObjects.Select(c => Create(c)).ToList();
            return result;
        }
    }
}
