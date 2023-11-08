using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAIN;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Test.Setup
{
    public class MainApp
    {
        public readonly TestServer _instance;
        public IServiceProvider ServiceProvider { get => _instance.Host.Services; }

        public MainApp()
        {
            _instance = new TestServer(WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .UseEnvironment("Test"));
        }

        public HttpClient CreateClient()
        {
            return _instance.CreateClient();
        }

        public void Dispose()
        {
            _instance.Dispose();
        }
    }
}
