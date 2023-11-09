using DATA.Enums;
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
            Assert.NotNull(responseData.Data);
            Assert.Equal(BOOKING_STATUS.NEW, responseData.Data.BookingStatus);
            Assert.Equal(BOOKING_FROM.CUSTOMER_APP, responseData.Data.BookingFrom);
        }
    }
}
