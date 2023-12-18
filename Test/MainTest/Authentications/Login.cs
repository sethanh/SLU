using SERVICE.Dtos.Authentications;
using SERVICE.Dtos.Results;
using Test.Setup;

namespace Test.MainTest.Authentications
{
    [Collection("Authentications")]
    public class Login : MainTestBase
    {

        private const string API_PATH = "/Authentications/Login";

        public Login(MainApp mainApp) : base(mainApp)
        {
        }

        public override Task SeedTestData()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task LoginUser()
        {   
            var httpClient = RegisterClient();

            var loginBody = new AuthenticateRequest
            {
                Password = MainSession.User.Password,
                Email = MainSession.User.Email
            };

            var response = await httpClient.PostAsJsonAsync(API_PATH, loginBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsAsync<ActionResultDto<AuthenticateResponse>>();

            Assert.NotNull(responseBody.Data);
            Assert.Equal(MainSession.User.Id, responseBody.Data.Id);
        }
    }
}
