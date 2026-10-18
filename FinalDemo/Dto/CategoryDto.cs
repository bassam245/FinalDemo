using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]


        public string Description { get; set; }
    }
}
