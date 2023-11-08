using CUSTOMER;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TechTalk.SpecFlow.xUnit.SpecFlowPlugin;
using Test.Setup;

[assembly: AssemblyFixture(typeof(CustomerApp))]

namespace Test.Setup
{
    public class CustomerApp
    {
        public readonly TestServer _customerAppInstance;
        private readonly MainApp _mainAppInstance;
        public IServiceProvider ServiceProvider { get => _customerAppInstance.Host.Services; }
        public HttpClient CustomerAnonymousClient { get; protected set; }
        public HttpClient MainAnonymousClient { get; protected set; }


        public CustomerApp()
        {
            _mainAppInstance = new MainApp();
            _customerAppInstance = new TestServer(WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .UseEnvironment("Test"));

            MainAnonymousClient = _mainAppInstance.CreateClient();
            MainAnonymousClient.GetAsync("/healthz").Wait();

            CustomerAnonymousClient = _customerAppInstance.CreateClient();
            CustomerAnonymousClient.GetAsync("/WeatherForecast").Wait();
        }

        public HttpClient CreateClient()
        {
            return _customerAppInstance.CreateClient();
        }

        public void Dispose()
        {
            _customerAppInstance.Dispose();
            CustomerAnonymousClient.Dispose();
        }

    }
}
