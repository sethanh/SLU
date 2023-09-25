using DATA.Enums;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Setup;

namespace Test.Main.Authentications
{
    public class Register : MainApp
    {

        private const string API_PATH = "api/Authentications/Register";

        public Register()
        {

        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Act
            var response = await AnonymousClient.GetAsync("/WeatherForecast");
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task FilterByDateRange()
        {
            var registerBody = new UserRegisterRequest
            {
                Name = "test",
                Password = "password",
                Email = "thas@gmail.com"
            };

            var response = await AnonymousClient.PostAsJsonAsync(API_PATH, registerBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserRegisterResponse>>();

            Assert.Equal(SUCCESS_MESSAGE.CREATE_USER_SUCCESS, responseData.Data.Message);
        }

       
    }
}
