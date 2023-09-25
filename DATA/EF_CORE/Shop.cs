using DATA.EF_BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class Shop : EntitiesBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Logo { get; set; }
        public string CoverPicture { get; set; }
        public DateTime Since { get; set; }
        public DateTime? OpenTime { get; set;  }
        public DateTime? CloseTime { get; set; }

        public ICollection<ShopBranch> ShopBranchs { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
