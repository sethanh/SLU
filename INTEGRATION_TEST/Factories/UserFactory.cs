using Bogus;
using DATA.EF_CORE;
using INTEGRATION_TEST.Utils;
using SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEGRATION_TEST.Factories
{
    public class UserFactory
    {
        public UserService UserService { get; private set; }

        public UserFactory(IServiceProvider serviceProvider)
        {
            UserService = (UserService)serviceProvider.GetService(typeof(UserService));
        }

        private User FakeForCreate()
        {
            return new Faker<User>();
        }

        public User Create(User user)
        {
            var fake = FakeForCreate();
            ObjectUtils.CopyValues(user, fake);
            return UserService.Add(fake);
        }
    }
}
