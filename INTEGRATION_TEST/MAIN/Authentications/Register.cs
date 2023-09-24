using DATA.Enums;
using INTEGRATION_TEST.Setup;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using Xunit;

namespace INTEGRATION_TEST.MAIN.Authentications
{
    [Collection("Authentications")]
    public class Register : MainTestBase
    {
        private const string API_PATH = "/Authentications";
        public Register(MainApp mainApp) : base(mainApp)
        {
        }

        public override  Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task FilterByDateRange()
        {
            var registerBody = new UserRegisterRequest
            {
                Name = "test",
                Password = "password",
                Email = Faker.Random.String2(10) + "@gmail.com"
            };

            var response = await AppClient.PutAsJsonAsync(API_PATH, registerBody);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserRegisterResponse>>();

            Assert.Equal(SUCCESS_MESSAGE.CREATE_USER_SUCCESS, responseData.Data.Message);
        }
    }
}
