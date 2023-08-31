using System.ComponentModel.DataAnnotations;

namespace MAIN.Dtos.Authentications
{
    public class AuthenticateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
