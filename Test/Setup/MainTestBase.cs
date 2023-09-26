using Microsoft.Extensions.DependencyInjection;
using Bogus;
using Test.Seeders;
using DATA.EF_CORE;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using Test.Infras;
using Test.Setup;
using TechTalk.SpecFlow.xUnit.SpecFlowPlugin;

[assembly: AssemblyFixture(typeof(MainApp))]

namespace Test.Setup
{
    public abstract class MainTestBase : IAsyncLifetime
    {
        private readonly MainApp _mainApp;
        private readonly IServiceScope _serviceScope;

        public virtual int HttpTimeoutMs => 180000;

        public readonly Faker Faker = new("vi");
        public HttpClient AppClient { get; private set; }
        public EntityFactories Factories { get; private set; }

        public SeedData SeedData { get; set; }
        public SeederBase Seeder { get; private set; }
        public MainSession MainSession { get; private set; }

        public MainTestBase( MainApp mainApp)
        {
            _mainApp = mainApp;
            _serviceScope = mainApp.ServiceProvider.CreateScope();
        }

        public abstract Task SeedTestData();

        public virtual async Task InitializeAsync()
        {
            MainSession = new MainSession(_serviceScope.ServiceProvider);
            AppClient = _mainApp.CreateClient();
            await SetupClientWithAuth(AppClient, MainSession.User);
            Factories = new EntityFactories(_serviceScope.ServiceProvider, AppClient);
            Seeder = new SeederBase(Factories);

            await SeedTestData();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public static async Task<Task> SetupClientWithAuth(HttpClient httpClient, User user)
        {
            string loginPath = "api/Authentications/Login";
            var loginBody = new AuthenticateRequest
            {
                Password = user.Password,
                Email = user.Email
            };

            var response = await httpClient.PostAsJsonAsync(loginPath, loginBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsAsync<ActionResultDto<AuthenticateResponse>>();

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {responseBody.Data.Token}");
            
            return Task.CompletedTask;
        }

        public HttpClient RegisterClient()
        {
            var httpClient = _mainApp.CreateClient();

            return httpClient;
        }

    }
}
