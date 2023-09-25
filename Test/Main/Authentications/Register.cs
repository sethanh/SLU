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
    [Collection("Authentications")]
    public class Register : MainTestBase
    {

        private const string API_PATH = "api/Authentications/Register";

        public Register(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task RegisterUser()
        {
            var registerBody = new UserRegisterRequest
            {
                Name = Faker.Name.FullName(),
                Password = Faker.Random.String2(10),
                Email = Faker.Internet.Email()
            };

            var response = await AppClient.PostAsJsonAsync(API_PATH, registerBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserRegisterResponse>>();

            Assert.Equal(SUCCESS_MESSAGE.CREATE_USER_SUCCESS, responseData.Data.Message);
        }

       
    }
}
