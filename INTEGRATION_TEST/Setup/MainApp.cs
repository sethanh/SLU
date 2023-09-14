using INTEGRATION_TEST.Infras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEGRATION_TEST.Setup
{
    public class MainApp
    {
        private readonly MainAppFactory _instance;

        public IServiceProvider ServiceProvider { get => _instance.Server.Host.Services; }

        public HttpClient AnonymousClient { get; protected set; }

        public MainApp()
        {
            _instance = new MainAppFactory();
            AnonymousClient = _instance.CreateClient();
            AnonymousClient.GetAsync("/WeatherForecast").Wait();
        }

        public HttpClient CreateClient()
        {
            return _instance.CreateClient();
        }
    }
}
