using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class ShopBranch : EntitiesBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool MainBranch { get; set; } 
        public DateTime? OpenTime { get; set;  }
        public DateTime? CloseTime { get; set; }
        public long ShopId { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
