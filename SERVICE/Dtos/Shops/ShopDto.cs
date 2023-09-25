using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Shops
{
    public class ShopDto : Shop
    {
        public string RegisterEmail { get; set; }
        public string PassWord { get; set; }
    }
}
