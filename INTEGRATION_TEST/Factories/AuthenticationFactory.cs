

using Bogus;
using DATA;
using DATA.EF_CORE;
using INTEGRATION_TEST.Infras;
using MAIN.Dtos.Authentications;

namespace INTEGRATION_TEST.Factories
{
    public class AuthenticationFactory : HttpFactoryBase<User, UserRegisterRequest>
    {
        public override string CreateUri => "/products";

        public AuthenticationFactory(HttpClient apiClient, Repository<User> repository) : base(apiClient, repository)
        {
        }

        public override UserRegisterRequest FakeDto()
        {
            return new Faker<UserRegisterRequest>();
        }
    }
}