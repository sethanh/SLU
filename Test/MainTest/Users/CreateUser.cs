using SERVICE.Dtos.Results;
using SERVICE.Dtos.Users;
using System.Net.Http.Json;
using Test.Setup;

namespace Test.MainTest.Users
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

            var userStorage = Factories.User.FindInDatabase(c => c.Email == postUserBody.Email).FirstOrDefault();

            //response Test
            Assert.NotNull(responseData.Data);
            Assert.Equal(postUserBody.Email, responseData.Data.Email);

            //storage Test
            Assert.NotNull(userStorage);
            Assert.Equal(userStorage?.Email, postUserBody.Email);
            Assert.Equal(userStorage?.Name, postUserBody.Name);
            Assert.Equal(userStorage?.Password, postUserBody.Password);

        }
    }
}
