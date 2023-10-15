using DATA.Enums;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using MAIN.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Test.Setup;

namespace Test.Main.Users
{
    [Collection("Users")]
    public class CreateUser : MainTestBase
    {
        private const string API_PATH = "/Users";

        public CreateUser(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Create_User()
        {
            var postUserBody = new UserDto {
                Password = Faker.Random.String2(10),
                Name = Faker.Name.FirstName(),
                Email = Faker.Internet.Email()
            };

            var response = await AppClient.PostAsJsonAsync(API_PATH,postUserBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserDto>>();

            Assert.NotNull(responseData.Data);
            Assert.Equal(postUserBody.Email, responseData.Data.Email);
        }
    }
}
