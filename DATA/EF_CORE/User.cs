using DATA.EF_BASE;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_CORE
{
    public class User : EntitiesBaseSecurity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? UserGroupId { get; set; }
        public long ShopBranchId { get; set;}
        public long ShopId { get; set; }
    }
}
