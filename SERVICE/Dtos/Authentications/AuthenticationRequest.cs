using System.ComponentModel.DataAnnotations;

namespace SERVICE.Dtos.Authentications
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class CustomerAuthenticateRequest
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
