using DATA.EF_CORE;
using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class BookingDetailServiceService : ApplicationService<BookingDetailService>
    {
        public BookingDetailServiceService(BookingDetailServiceManager domainService) : base(domainService)
        {
        }
    }
}
