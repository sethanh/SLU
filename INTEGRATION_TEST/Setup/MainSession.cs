using DATA.EF_CORE;
using INTEGRATION_TEST.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEGRATION_TEST.Setup
{
    public class MainSession
    {
        private readonly UserFactory _userFactory;
        private static Random random = new Random();

        public User User { get; protected set; }

        public MainSession(IServiceProvider serviceProvider)
        {
            _userFactory = new UserFactory(serviceProvider);
            RegisterUser();
        }

        private void RegisterUser()
        {
            User = _userFactory.Create(new User()
            {
                Email = RandomString(10)+"@gmail.com",
                Name = RandomString(6) + ' ' + RandomString(5) + ' ' + RandomString(5),
                Password = RandomString(10),
            });
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
