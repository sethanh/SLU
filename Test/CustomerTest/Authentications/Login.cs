using DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SERVICE.Dtos.Authentications;
using SERVICE.Dtos.BookingDetailObjects;
using SERVICE.Dtos.BookingDetails;
using SERVICE.Dtos.Bookings;
using SERVICE.Dtos.Results;
using Test.Setup;

namespace Test.CustomerTest.Bookings
{
    [Collection("Authentications")]
    public class Login : CustomerTestBase
    {
        private const string API_PATH = "/Authentications/Login";

        public Login(CustomerApp customerApp) : base(customerApp) { }

        protected override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Login_Success()
        {
            var loginBody = new CustomerAuthenticateRequest
            {
                Password = CustomerSession.CustomerAccount.Password,
                Mobile = CustomerSession.CustomerAccount.Mobile
            };

            var response = await CustomerAnonymousClient.PostAsJsonAsync(API_PATH, loginBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsAsync<ActionResultDto<CustomerAuthenticateResponse>>();

            Assert.NotNull(responseBody.Data);
            Assert.Equal(CustomerSession.CustomerAccount.Id, responseBody.Data.Id);
        }

        [Fact]
        public async Task Login_Return_Not_Found()
        {
            var loginBody = new CustomerAuthenticateRequest
            {
                Password = Faker.Random.String2(8),
                Mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty)
            };

            var response = await CustomerAnonymousClient.PostAsJsonAsync(API_PATH, loginBody);

            Assert.Equal(System.Net.HttpStatusCode.NotFound,response.StatusCode);
        }
    }
}
