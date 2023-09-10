using DATA.EF_CORE;
using SERVICE.Helpers;

namespace UNIT_TEST.Main.Helpers
{
    public class AuthenticationHelperTest
    {
        public AuthenticationHelperTest()
        {
        }

        [Fact]
        public void ShouldReturnGetJwtSecurityToken()
        {
            var user = new User
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "password123"

            };

            string jwtKeyString = "PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f";
            string jwtIssuer = "708ad04bb42fd613f8cf9ff5f0fa58855f33b994";

            var result = AuthenticationHelper.GetJwtSecurityToken(
                user,
                jwtKeyString,
                jwtIssuer
            );

            Assert.NotNull(result);
            Assert.True(result != null, result);
        }
    }
}