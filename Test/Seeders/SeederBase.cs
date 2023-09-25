using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Seeders
{
    public partial class SeederBase
    {
        private readonly EntityFactories _factories;

        public SeederBase(EntityFactories entityFactories)
        {
            _factories = entityFactories;
        }
    }
}
