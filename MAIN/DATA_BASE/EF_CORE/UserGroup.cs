using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA_BASE.EF_CORE
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
