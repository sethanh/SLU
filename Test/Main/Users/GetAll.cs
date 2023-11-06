using DATA.Enums;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using MAIN.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Setup;

namespace Test.Main.Users
{
    [Collection("Users")]
    public class GetAll : MainTestBase
    {
        private const string API_PATH = "/Users";

        public GetAll(MainApp mainApp) : base(mainApp)
        {
        }

        public override async Task SeedTestData()
        {
            SeedData = await Seeder.SeedUser();
        }

        [Fact]
        public async Task GetAll_User()
        {

            var response = await AppClient.GetAsync(API_PATH);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<List<UserDto>>>();

            Assert.NotNull(responseData.Data);
            Assert.Equal(2, responseData.Data.Count);
        }
    }
}
