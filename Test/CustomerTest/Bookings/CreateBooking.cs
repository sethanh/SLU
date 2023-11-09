using DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SERVICE.Dtos.BookingDetailObjects;
using SERVICE.Dtos.BookingDetails;
using SERVICE.Dtos.Bookings;
using SERVICE.Dtos.Results;
using Test.Setup;

namespace Test.CustomerTest.Bookings
{
    [Collection("WeatherForecast")]
    public class CreateBooking : CustomerTestBase
    {
        private const string API_PATH = "Bookings";

        public CreateBooking(CustomerApp customerApp) : base(customerApp) { }

        protected override async Task SeedTestData()
        {
            SeedData = await Seeder.SeedService(100_000);
        }

        [Fact]
        public async Task Create_With_Single_Detail()
        {
            var bookingDto = new BookingDto
            {
                Date = DateTime.Now,
                BookingStatus = BOOKING_STATUS.NEW,
                ShopId = MainSession.Shop.Id,
                ShopBranchId = MainSession.ShopBranch.Id,
                BookingDetails = new List<BookingDetailDto>()
                {
                    new BookingDetailDto
                    {
                        Note = "customer_01",
                        BookingDetailObjects = new List<BookingDetailObjectDto>()
                        { 
                            new BookingDetailObjectDto 
                            {
                                ServiceId = SeedData.Service?.Id
                            } 
                        }
                    }
                }
            };

            var response = await CustomerClient.PostAsJsonAsync(API_PATH, bookingDto);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<BookingDto>>();

            var getMainBookingById = await MainClient.GetAsync($"{API_PATH}/{responseData.Data.Id}");
            var getMainBookingByIdData = await getMainBookingById.Content.ReadAsAsync<ActionResultDto<BookingDto>>();

            var bookingStorage = Factories.Booking.GetAll()
                .Where(c => c.Id == responseData.Data.Id)
                .Include(c => c.BookingDetails)
                    .ThenInclude(c => c.BookingDetailObjects)
                .FirstOrDefault();
            var bookingDetailObjectStorage = bookingStorage?.BookingDetails.FirstOrDefault()?.BookingDetailObjects.FirstOrDefault();

            //Test response
            Assert.NotNull(responseData.Data);
            Assert.NotNull(responseData.Data.Id);
            Assert.Equal(BOOKING_STATUS.NEW, responseData.Data.BookingStatus);
            Assert.Equal(BOOKING_FROM.CUSTOMER_APP, responseData.Data.BookingFrom);
            Assert.Equal(CustomerSession.Customer.Id, responseData.Data.CustomerId);

            //Test get booking by Main App
            Assert.NotNull(getMainBookingByIdData.Data);
            Assert.Equal(BOOKING_STATUS.NEW, getMainBookingByIdData.Data.BookingStatus);
            Assert.Equal(BOOKING_FROM.CUSTOMER_APP, getMainBookingByIdData.Data.BookingFrom);
            Assert.Equal(CustomerSession.Customer.Id, getMainBookingByIdData.Data.CustomerId);

            //Test data base
            Assert.NotNull(bookingStorage);
            Assert.Equal(BOOKING_STATUS.NEW, bookingStorage?.BookingStatus);
            Assert.Equal(BOOKING_FROM.CUSTOMER_APP, bookingStorage?.BookingFrom);
            Assert.Equal(CustomerSession.Customer.Id, bookingStorage?.CustomerId);

            Assert.NotNull(bookingDetailObjectStorage);
            Assert.NotNull(bookingDetailObjectStorage?.ServiceId);
            Assert.Equal(SeedData?.Service?.Id, bookingDetailObjectStorage?.ServiceId);

        }
    }
}
