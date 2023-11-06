using Test.Setup;

namespace Test.Main.WeatherForecasts
{
    [Collection("WeatherForecast")]
    public class GetWeatherForecast : MainTestBase
    {
        private const string API_PATH = "WeatherForecast";

        public GetWeatherForecast(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Get_WeatherForecast()
        {

            var response = await AppClient.GetAsync(API_PATH);
            response.EnsureSuccessStatusCode();
        }
    }
}
