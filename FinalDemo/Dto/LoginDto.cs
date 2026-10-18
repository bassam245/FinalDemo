using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]

        public string PasswordHash { get; set; }
    }
}
