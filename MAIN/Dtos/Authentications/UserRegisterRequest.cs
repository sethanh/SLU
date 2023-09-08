using System.ComponentModel.DataAnnotations;

namespace MAIN.Dtos.Authentications
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
