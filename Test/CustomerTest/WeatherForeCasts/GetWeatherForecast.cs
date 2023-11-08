using Microsoft.Extensions.Configuration;
using Test.Setup;

namespace Test.CustomerTest.WeatherForecasts
{
    [Collection("WeatherForecast")]
    public class GetWeatherForecast : CustomerTestBase
    {
        private const string API_PATH = "WeatherForecast";

        public GetWeatherForecast(CustomerApp customerApp) : base(customerApp){}

        protected override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Get_WeatherForecast()
        {
            var response = await CustomerClient.GetAsync(API_PATH);
            response.EnsureSuccessStatusCode();
        }
    }
}
