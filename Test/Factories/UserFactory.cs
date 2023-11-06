using Bogus;
using DATA;
using DATA.EF_CORE;
using MAIN.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Infras;

namespace Test.Factories
{
    public class UserFactory : HttpFactoryBase<User, UserDto>
    {
        public override string CreateUri => "Users";

        public UserFactory(HttpClient apiClient, Repository<User> repository) : base(apiClient, repository)
        {
        }

        public override UserDto FakeDto()
        {
            return new Faker<UserDto>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Password, f => f.Random.String2(10));
        }
    }
}
