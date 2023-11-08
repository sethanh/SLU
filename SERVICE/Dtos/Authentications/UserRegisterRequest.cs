using System.ComponentModel.DataAnnotations;

namespace SERVICE.Dtos.Authentications
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public long? SalonId { get; set; }
        public long? SalonBranchId { get; set; }
    }
    
    public class CustomerAccountRegister
    {
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
