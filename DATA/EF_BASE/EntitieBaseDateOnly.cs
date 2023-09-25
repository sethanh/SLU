using System;

namespace DATA.EF_BASE
{
    public class EntitiesBaseDateOnly
    {
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
