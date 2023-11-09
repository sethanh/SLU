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
    public class BookingDetailCoreService : ApplicationService<BookingDetail>
    {
        public BookingDetailCoreService(BookingDetailManager domainService) : base(domainService)
        {
        }
    }
}
