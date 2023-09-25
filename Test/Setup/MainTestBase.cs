using MAIN;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Bogus;
using Test.Seeders;
using DATA.EF_CORE;

namespace Test.Setup
{
    public abstract class MainTestBase : IAsyncLifetime
    {
        private readonly MainApp _mainApp;
        private readonly IServiceScope _serviceScope;

        public readonly Faker Faker = new("vi");
        public HttpClient AppClient { get; private set; }
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
            var factoryClient = _mainApp.CreateClient();

            await SeedTestData();
        }

        public Task DisposeAsync()
        {
            AppClient.Dispose();
            _mainApp.Dispose();
            return Task.CompletedTask;
        }

        public void SetupClientWithAuth(HttpClient httpClient, User user)
        {
            //var authService = _serviceScope.ServiceProvider.GetRequiredService<AuthService>();
            //var tokens = authService.RequestToken(user);
            //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokens.Token}");
        }


    }
}
