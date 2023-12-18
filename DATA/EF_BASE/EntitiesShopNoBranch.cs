using DATA.EF_BASE;
using DATA.EF_CORE;
using DATA.Enums;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_BASE
{
    public class EntitiesShopNoBranch : EntitiesBase
    {
        public long? ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
