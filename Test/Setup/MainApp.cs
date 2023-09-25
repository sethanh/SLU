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
    public abstract class MainApp : IAsyncLifetime
    {
        private readonly TestServer _instance;

        public IServiceScope _serviceScope { get; private set; }

        public readonly Faker Faker = new("vi");

        public HttpClient AnonymousClient;
        public HttpClient AppClient { get; private set; }
        public SeedData SeedData { get; set; }
        public SeederBase Seeder { get; private set; }
        public MainSession MainSession { get; private set; }

        public MainApp()
        {
            _instance = new TestServer(WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .UseEnvironment("Test"));
            AnonymousClient = _instance.CreateClient();
            AppClient = _instance.CreateClient();
            _serviceScope = _instance.Host.Services.CreateScope();
        }

        public abstract Task SeedTestData();

        public virtual async Task InitializeAsync()
        {
            var factoryClient = _instance.CreateClient();

            await SeedTestData();
        }

        public Task DisposeAsync()
        {
            AnonymousClient.Dispose();
            AppClient.Dispose();
            _instance.Dispose();
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
