using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Seeders
{
    public class SeedData
    {
        public User? User { get; set; }
        public Customer? Customer { get; set; }
        public Service? Service { get; set; }
    }
}
