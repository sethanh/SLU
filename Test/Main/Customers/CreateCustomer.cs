using SERVICE.Dtos.Results;
using SERVICE.Dtos.Customers;
using System.Net.Http.Json;
using Test.Setup;

namespace Test.Main.Customers
{
    [Collection("Customers")]
    public class CreateCustomer : MainTestBase
    {
        private const string API_PATH = "/Customers";

        public CreateCustomer(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Create_Customer()
        {
            var postCustomerBody = new CustomerDto {
                Address = Faker.Address.FullAddress(),
                Mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty),
                Name = Faker.Name.FirstName(),
                Email = Faker.Internet.Email()
            };

            var response = await AppClient.PostAsJsonAsync(API_PATH,postCustomerBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<CustomerDto>>();
            var customerStorage = Factories.Customer.FindInDatabase(c => c.Email == postCustomerBody.Email).FirstOrDefault();

            var getCustomerbyIdResponse =  await AppClient.GetAsync($"{API_PATH}/{responseData.Data.Id}");
            var getCustomerbyIdResponseData = await response.Content.ReadAsAsync<ActionResultDto<CustomerDto>>();

            var getCustomerbyMobileResponse =  await AppClient.GetAsync($"{API_PATH}?customerMobile={postCustomerBody.Mobile}");
            var getCustomerbyMobileResponseData = await response.Content.ReadAsAsync<ActionResultDto<List<CustomerDto>>>();

            //response create customer test
            Assert.NotNull(responseData.Data);
            Assert.Equal(postCustomerBody.Mobile, responseData.Data.Mobile);
            Assert.Equal(MainSession.Shop.Id, responseData.Data.Id);

            //response get customer by Id
            Assert.NotNull(getCustomerbyIdResponseData.Data);
            Assert.Equal(responseData.Data.Mobile, getCustomerbyIdResponseData.Data.Mobile);

            //response get customer by mobile
            Assert.NotNull(getCustomerbyMobileResponseData.Data);
            Assert.Equal(postCustomerBody.Mobile, getCustomerbyMobileResponseData.Data[0].Mobile);
            Assert.Equal(responseData.Data.Id, getCustomerbyMobileResponseData.Data[0].Id);

            //storage Test
            Assert.NotNull(customerStorage);
            Assert.Equal(customerStorage?.Email, postCustomerBody.Email);
            Assert.Equal(customerStorage?.Name, postCustomerBody.Name);
            Assert.Equal(customerStorage?.Mobile, postCustomerBody.Mobile);
            Assert.Equal(customerStorage?.Address, postCustomerBody.Address);
            Assert.Equal(MainSession.Shop.Id, customerStorage?.Id);


        }
    }
}
