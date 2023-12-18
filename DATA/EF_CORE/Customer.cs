using DATA.EF_BASE;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.EF_CORE
{
    public class Customer : EntitiesBaseSecurity
    {
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Sex { get; set; }
        public string AvatarUrl { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Code { get; set; }
        public long ShopId { get; set; }
        public Shop Shop { get; set; }
        public long? CustomerAccountId { get; set;}
        public CustomerAccount CustomerAccount { get; set;}
    }
}
