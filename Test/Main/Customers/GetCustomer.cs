using SERVICE.Dtos.Results;
using SERVICE.Dtos.Customers;
using System.Net.Http.Json;
using Test.Setup;
using Test.Seeders;

namespace Test.Main.Customers
{
    [Collection("Customers")]
    public class GetCustomer : MainTestBase
    {
        private const string API_PATH = "/Customers";

        public GetCustomer(MainApp mainApp) : base(mainApp)
        {
        }

        public override async Task SeedTestData()
        {
            var customerSeed = await Factories.Customer.Create();

            SeedData = new SeedData
            {
                Customer = customerSeed
            };
        }

        [Fact]
        public async Task Get_All_Customer()
        {
            var getCustomerResponse =  await AppClient.GetAsync($"{API_PATH}");
            var getCustomerResponseData = await getCustomerResponse.Content.ReadAsAsync<ActionResultDto<List<CustomerDto>>>();

            var customerIds = getCustomerResponseData.Data.Select(c => c.Id).ToList();
            var isExistedCustomer = customerIds.Contains(SeedData.Customer?.Id);

            Assert.NotNull(getCustomerResponseData.Data);
            Assert.True(isExistedCustomer);
        }

        [Fact]
        public async Task Get_Customer_By_Mobile()
        {
            var getCustomerResponse =  await AppClient.GetAsync($"{API_PATH}?customerMobile={SeedData.Customer?.Mobile}");
            var getCustomerResponseData = await getCustomerResponse.Content.ReadAsAsync<ActionResultDto<List<CustomerDto>>>();

            var customer = getCustomerResponseData.Data.FirstOrDefault(c => c.Id == SeedData.Customer?.Id);

            Assert.NotNull(getCustomerResponseData.Data);
            Assert.NotNull(customer);
            Assert.Equal(SeedData.Customer?.Mobile, customer?.Mobile);
            Assert.Equal(SeedData.Customer?.Address, customer?.Address);
        }

        [Fact]
        public async Task Get_Customer_By_Id()
        {
            var getCustomerResponse =  await AppClient.GetAsync($"{API_PATH}/{SeedData.Customer?.Id}");
            var getCustomerResponseData = await getCustomerResponse.Content.ReadAsAsync<ActionResultDto<CustomerDto>>();

            Assert.NotNull(getCustomerResponseData.Data);
            Assert.Equal(SeedData.Customer?.Mobile, getCustomerResponseData.Data.Mobile);
            Assert.Equal(SeedData.Customer?.Address, getCustomerResponseData.Data.Address);
            Assert.Equal(SeedData.Customer?.Id, getCustomerResponseData.Data.Id);
        }
    }
}
