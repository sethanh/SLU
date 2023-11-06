using SERVICE.Dtos.Results;
using SERVICE.Dtos.Users;
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
