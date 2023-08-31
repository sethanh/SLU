using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class User : EntitieBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public long? UserGroupId { get; set; }
    }
}
