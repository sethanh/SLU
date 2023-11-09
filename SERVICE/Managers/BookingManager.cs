using DATA.EF_CORE;
using DATA;

namespace SERVICE.Managers
{
    public class BookingManager : DomainService<Booking>
    {
        public BookingManager(UnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
