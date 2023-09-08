using DATA.EF_BASE;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_BASE
{
    public class EntitiesBase : EntitiesBaseDateOnly
    {
        [Key]
        public long Id { get; set; }
        public string Status { get; set; }
  
    }
}
