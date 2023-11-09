using DATA.EF_CORE;
using SERVICE.Dtos.BookingDetails;
using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class BookingDetailService : ApplicationService<BookingDetail>
    {
        public BookingDetailService(BookingDetailManager domainService) : base(domainService)
        {
        }
    }
}
