using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class Booking : EntitiesBaseShop
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Code { get; set; }
        public string BookingStatus { get; set; }
        public string BookingFrom { get; set; }
        public string Note { get; set; }
        public ICollection<BookingDetail> BookingDetails { get; set; }

    }
}
