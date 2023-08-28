﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA_BASE.EF_CORE
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserGroupId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
