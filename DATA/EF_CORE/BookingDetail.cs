using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class BookingDetail: EntitiesBaseShop
    {
        public long BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public string Note { get; set; }
        public ICollection<BookingDetailService> BookingDetailServices { get; set; }
    }
}
