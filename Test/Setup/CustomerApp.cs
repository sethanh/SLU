using CUSTOMER;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TechTalk.SpecFlow.xUnit.SpecFlowPlugin;
using Test.Infras;
using Test.Setup;

[assembly: AssemblyFixture(typeof(CustomerApp))]

namespace Test.Setup
{
    public class CustomerApp
    {
        public readonly CustomerAppFactory _customerAppInstance;
        private readonly MainApp _mainAppInstance;
        public IServiceProvider ServiceProvider { get => _customerAppInstance.Services; }

        public CustomerApp()
        {
            _mainAppInstance = new MainApp();
            _customerAppInstance = new CustomerAppFactory();
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
