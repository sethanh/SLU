using DATA.EF_BASE;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_BASE
{
    public class EntitieBase : EntitieBaseDateOnly
    {
        [Key]
        public long Id { get; set; }
        public string Status { get; set; }
  
    }
}
