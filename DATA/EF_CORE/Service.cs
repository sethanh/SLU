using DATA.EF_BASE;
using DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.EF_CORE
{
    public class Service : EntitiesBaseShop
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string TimeUnit { get; set; } = TIME_UNIT.MINUTE;
        public int? TimeValue { get; set; } = 0;
    }
}
