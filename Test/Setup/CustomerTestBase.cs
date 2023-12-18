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
using SERVICE.Helpers;

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
            SetupCustomer();
            Factories = new EntityFactories(_serviceScope.ServiceProvider, MainClient);
            Seeder = new SeederBase(Factories);
    
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
            var authService = _serviceScope.ServiceProvider.GetRequiredService<AuthenticationService>();

            string name = Faker.Name.FullName();
            string mobile = Faker.Phone.PhoneNumber().Replace(" ", string.Empty);
            string address = Faker.Address.FullAddress();

            var customerAccountDto = new CustomerAccountDto
            {
                Name = name,
                Mobile = mobile,
                Address = address,
                Password = Faker.Random.String2(8)
            };

            var customerAccount = customerAccountService.CreateCustomerAccount(customerAccountDto);

            var customerDto = new CustomerDto
            {
                Name = name,
                Mobile = mobile,
                Address = address
            };

            var customer = customerService.CreateCustomer(customerDto, MainSession.Shop.Id);

            MainClient = Apps.CreateMainClient();
            var mainToken = AuthenticationHelper.GetJwtSecurityToken(
                MainSession.User, 
                authService.GetJwtKeyString(), 
                authService.GetJwtIssuer()
            );
            SetupClientWithAuth(MainClient, mainToken);

            CustomerClient = Apps.CreateCustomerClient();
            var customerToken = AuthenticationHelper.GetCustomerJwtSecurityToken(
                customerAccount, 
                customerAccountService.GetJwtKeyString(), 
                customerAccountService.GetJwtIssuer()
            );
            SetupClientWithAuth(CustomerClient, customerToken);

            CustomerSession = new CustomerSession
            {
                Token = customerToken,
                CustomerAccount = customerAccount,
                Customer = customer
            };

            MainAnonymousClient = Apps.CreateMainClient();
            CustomerAnonymousClient = Apps.CreateCustomerClient();
            
            customerAccountService.ResetTracker();
        }

        public void SetupClientWithAuth(HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
