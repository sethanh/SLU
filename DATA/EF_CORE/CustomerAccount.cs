using DATA.EF_BASE;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.EF_CORE
{
    public class CustomerAccount : EntitieBaseSecurity
    {
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Password { get; set; }

        public bool IsVerify { get; set; }

        public string CustomerCode { get; set; }

        public DateTime? Birthday { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
    }
}
