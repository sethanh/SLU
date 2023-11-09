using DATA.EF_CORE;
using SERVICE.Dtos.BookingDetailObjects;
using SERVICE.Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.BookingDetails
{
    public class BookingDetailDto
    {
        public long? Id { get; set; }
        public long? BookingId { get; set; }
        public string Note { get; set; }
        public long? ShopId { get; set; }
        public long? ShopBranchId { get; set; }
        public List<BookingDetailObjectDto> BookingDetailObjects { get; set; }

        public static BookingDetailDto Create(BookingDetail bookingDetail)
        {
            return new BookingDetailDto
            {
                Id = bookingDetail.Id,
                BookingId = bookingDetail.BookingId,
                Note = bookingDetail.Note,
                ShopId = bookingDetail.ShopId,
                ShopBranchId = bookingDetail.ShopBranchId,
                BookingDetailObjects = bookingDetail.BookingDetailObjects != null 
                    ? BookingDetailObjectDto.Create(bookingDetail.BookingDetailObjects.ToList())
                    : null
            };
        }

        public static List<BookingDetailDto> Create(List<BookingDetail> bookingDetails)
        {
            var result =  bookingDetails.Select(c => Create(c)).ToList();
            return result;
        }
    }
}
