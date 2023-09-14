using DATA.EF_CORE;
using INTEGRATION_TEST.Infras;
using INTEGRATION_TEST.Seeder;
using Microsoft.Extensions.DependencyInjection;
using SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace INTEGRATION_TEST.Setup
{
    public abstract class MainTestBase : IAsyncLifetime
    {
        private readonly MainApp _mainApp;
        private readonly IServiceScope _serviceScope;

        public virtual int HttpTimeoutMs => 5000;

        public EntityFactories Factories { get; private set; }

        public SeederBase Seeder { get; private set; }

        public SeedData SeedData { get; set; }

        public MainSession AuthState { get; private set; }

        public HttpClient AppClient { get; private set; }

        public MainTestBase(MainApp mainApp)
        {
            _mainApp = mainApp;
            _serviceScope = mainApp.ServiceProvider.CreateScope();

        }

        public virtual Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual async Task InitializeAsync()
        {
            AuthState = new MainSession(_serviceScope.ServiceProvider);

            var factoryClient = _mainApp.CreateClient();
            SetupClientWithAuth(factoryClient, AuthState.User);
            Factories = new EntityFactories(_serviceScope.ServiceProvider, factoryClient);
            Seeder = new SeederBase(Factories);

            AppClient = _mainApp.CreateClient();
            SetupClientWithAuth(AppClient, AuthState.User);
            AppClient.Timeout = TimeSpan.FromMilliseconds(HttpTimeoutMs);

            await SeedTestData();
        }

        public abstract Task SeedTestData();

        public void SetupClientWithAuth(HttpClient httpClient, User user)
        {
            var authService = _serviceScope.ServiceProvider.GetRequiredService<AuthenticationService>();
            var tokens = authService.GetJwtSecurityToken(
                user,
                "PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f",
                "708ad04bb42fd613f8cf9ff5f0fa58855f33b994"
                );
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokens}");
        }
    }
}
