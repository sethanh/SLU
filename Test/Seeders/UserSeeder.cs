using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Seeders
{
    public partial class SeederBase
    {
        public async Task<SeedData> SeedUser()
        {
            var user = await _factories.User.Create();

            return new SeedData
            {
                User = user
            };
        }
    }
}
