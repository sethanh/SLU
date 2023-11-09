using DATA.EF_CORE;
using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Managers
{
    public class BookingDetailServiceManager : DomainService<BookingDetailService>
    {
        public BookingDetailServiceManager(UnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
