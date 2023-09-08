using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class UserGroup : EntitiesBase
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
