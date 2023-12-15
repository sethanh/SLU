using Test.Infras;

namespace Test.Setup
{
    public class MainApp
    {
        private readonly MainAppFactory _instance;
        public IServiceProvider ServiceProvider { get => _instance.Services; }

        public MainApp()
        {
            _instance = new MainAppFactory();
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
