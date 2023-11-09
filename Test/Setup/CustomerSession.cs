using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Setup
{
    public class CustomerSession
    {
        public string Token { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
        public Customer Customer { get; set; }
    }
}
