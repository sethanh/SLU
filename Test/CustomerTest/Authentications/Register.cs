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
    public class Register : CustomerTestBase
    {
        private const string API_PATH = "/Authentications/Register";

        public Register(CustomerApp customerApp) : base(customerApp) { }

        protected override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Register_Success()
        {
            var registerBody = new CustomerAccountRegister
            {
                Mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty),
                Password = Faker.Random.String2(8),
            };

            var response = await CustomerAnonymousClient.PostAsJsonAsync(API_PATH, registerBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsAsync<ActionResultDto<CustomerAuthenticateResponse>>();

            var loginBody = new CustomerAuthenticateRequest
            {
                Password = registerBody.Password,
                Mobile = registerBody.Mobile
            };

            var responseLogin = await CustomerAnonymousClient.PostAsJsonAsync("/Authentications/Login", loginBody);
            responseLogin.EnsureSuccessStatusCode();
            var responseLoginBody = await responseLogin.Content.ReadAsAsync<ActionResultDto<CustomerAuthenticateResponse>>();
            
            //Test response register
            Assert.NotNull(responseBody.Data);

            //Test response login
            Assert.NotNull(responseLoginBody.Data);
            Assert.Equal(responseBody.Data.Id, responseLoginBody.Data.Id);
        }

        [Fact]
        public async Task Register_Return_Bad_Request()
        {
            var registerBody = new CustomerAuthenticateRequest
            {
                Password = Faker.Random.String2(8),
                Mobile = CustomerSession.CustomerAccount.Mobile
            };

            var response = await CustomerAnonymousClient.PostAsJsonAsync(API_PATH, registerBody);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest,response.StatusCode);
            Assert.Equal(BAD_REQUEST_MESSAGE.EXISTED_CUSTOMER, response.Content.ReadAsStringAsync().Result);
        }
    }
}
