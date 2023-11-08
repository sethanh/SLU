using Bogus;
using Microsoft.Extensions.DependencyInjection;
using SERVICE.Dtos.CustomerAccounts;
using SERVICE.Dtos.Customers;
using SERVICE.Dtos.Results;
using SERVICE.Services;
using TechTalk.SpecFlow.xUnit.SpecFlowPlugin;
using Test.Infras;
using Test.Seeders;
using DATA.EF_CORE;
using SERVICE.Dtos.Authentications;
using Test.Setup;
using Microsoft.Extensions.Configuration;

namespace Test.Setup
{
    public abstract class CustomerTestBase : IAsyncLifetime
    {
        private readonly CustomerApp Apps;
        private readonly IServiceScope _serviceScope;
        public virtual int HttpTimeoutMs => 180000;
        public readonly Faker Faker = new Faker("vi");
        public MainSession MainSession { get; private set; }
        public CustomerSession CustomerSession { get; private set; }
        public EntityFactories Factories { get; private set; }
        public SeedData SeedData { get; set; }
        public SeederBase Seeder { get; private set; }

        public HttpClient MainAnonymousClient { get; private set; }
        public HttpClient MainClient { get; private set; }

        public HttpClient CustomerAnonymousClient { get; private set; }
        public HttpClient CustomerClient { get; private set; }

        public CustomerTestBase(
            CustomerApp customerApp
            )
        {
            Apps = customerApp;
            _serviceScope = customerApp.ServiceProvider.CreateScope();
        }

        protected abstract Task SeedTestData();

        public virtual async Task InitializeAsync()
        {
            MainSession = new MainSession(_serviceScope.ServiceProvider);
            Factories = new EntityFactories(_serviceScope.ServiceProvider, MainClient);
            Seeder = new SeederBase(Factories);
            SetupCustomer();

            await SeedTestData();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        private void SetupCustomer()
        {
            var customerAccountService = _serviceScope.ServiceProvider.GetRequiredService<CustomerAccountService>();
            var customerService = _serviceScope.ServiceProvider.GetRequiredService<CustomerService>();
            var authenService = _serviceScope.ServiceProvider.GetRequiredService<AuthenticationService>();

            var customerDto = new CustomerDto
            {
                Name = Faker.Name.FullName(),
                Mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty),
                Address = Faker.Address.FullAddress()
            };

            customerService.CreateCustomer(customerDto, MainSession.Shop.Id);

            var customerAccountDto = new CustomerAccountDto
            {
                Name = Faker.Name.FullName(),
                Mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty),
                Address = Faker.Address.FullAddress(),
                Password = Faker.Random.String2(8)
            };

            var customerAccount = customerAccountService.CreateCustomerAccount(customerAccountDto);

            string jwtKeyString = "PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f";
            string jwtIssuer = "708ad04bb42fd613f8cf9ff5f0fa58855f33b994";

            MainClient = Apps.CreateClient();
            var mainToken = authenService.GetJwtSecurityToken(MainSession.User, jwtKeyString, jwtIssuer);
            SetupClientWithAuth(MainClient, mainToken);

            CustomerClient = Apps.CreateClient();
            var customerToken = customerAccountService.GetJwtSecurityToken(customerAccount, jwtKeyString, jwtIssuer);
            SetupClientWithAuth(CustomerClient, customerToken);

            CustomerSession = new CustomerSession
            {
                Token = customerToken,
                CustomerAccount = customerAccount
            };
        }

        public void SetupClientWithAuth(HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
