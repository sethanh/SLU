using DATA.EF_BASE;
using DATA.EF_CORE;
using DATA.Enums;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_BASE
{
    public class EntitiesBaseShop : EntitiesBase
    {
        public long? ShopId { get; set; }
        public Shop Shop { get; set; }
        public long? ShopBranchId  { get; set; }
        public ShopBranch ShopBranch { get; set; }

    }
}
