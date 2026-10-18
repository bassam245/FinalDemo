using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]

        public string PasswordHash { get; set; }
    }
}
