using Bogus;
using DATA;
using DATA.EF_CORE;
using SERVICE.Dtos.Bookings;
using Test.Infras;

namespace Test.Factories
{
    public class BookingFactory : HttpFactoryBase<Booking, BookingDto>
    {
        public override string CreateUri => "Bookings";

        public BookingFactory(HttpClient apiClient, Repository<Booking> repository) : base(apiClient, repository)
        {
        }

        public override BookingDto FakeDto()
        {
            return new Faker<BookingDto>();
        }
    }
}
