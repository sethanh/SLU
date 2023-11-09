using DATA.EF_BASE;

namespace DATA.EF_CORE
{
    public class BookingDetailObject: EntitiesBase
    {
        public long? BookingId { get; set; }
        public Booking Booking { get; set; }
        public long BookingDetailId { get; set; }
        public BookingDetail BookingDetail { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
