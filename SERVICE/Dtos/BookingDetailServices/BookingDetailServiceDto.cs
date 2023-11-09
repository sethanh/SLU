using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.BookingDetailServices
{
    public class BookingDetailServiceDto
    {
        public long? Id { get; set; }
        public long? BookingId { get; set; }
        public long? BookingDetailId { get; set; }
        public long? ServiceId { get; set; }
    }
}
