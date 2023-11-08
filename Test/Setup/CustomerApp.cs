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


        public CustomerApp()
        {
            _mainAppInstance = new MainApp();
            _customerAppInstance = new TestServer(WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .UseEnvironment("Test"));
        }

        public HttpClient CreateCustomerClient()
        {
            return _customerAppInstance.CreateClient();
        }

        public HttpClient CreateMainClient()
        {
            return _mainAppInstance.CreateClient();
        }

        public void Dispose()
        {
            _customerAppInstance.Dispose();
            _mainAppInstance.Dispose();
        }

    }
}
