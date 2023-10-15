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
    public class UpdateUser : MainTestBase
    {
        private const string API_PATH = "/Users";

        public UpdateUser(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Update_User()
        {
            var putUserBody = new UserDto {
                Password = SECURITY_VALUE.PASSWORD,
                Name = "Ten Thay doi"
            };

            var response = await AppClient.PutAsJsonAsync($"{API_PATH}/{MainSession.User.Id}",putUserBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserDto>>();

            Assert.NotNull(responseData.Data);
            Assert.Equal(MainSession.User.Id, responseData.Data.Id);
        }
    }
}
