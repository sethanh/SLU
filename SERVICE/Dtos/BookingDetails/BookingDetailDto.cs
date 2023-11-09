using DATA.EF_CORE;
using SERVICE.Dtos.BookingDetailServices;
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
        public List<BookingDetailServiceDto> BookingDetailServices { get; set; }
    }
}
