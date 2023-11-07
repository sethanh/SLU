using DATA.EF_BASE;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.EF_CORE
{
    public class CustomerAccountDevice : EntitieBaseSecurity
    {
        public string DeviceID { get; set; }
        public string DeviceToken { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string DeviceName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Os { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string OsVersion { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Manufacturer { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string DeviceType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string SdkVersion { get; set; }
        public long CustomerAccountId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
    }
}
