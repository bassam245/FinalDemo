using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]


        public string Description { get; set; }
    }
}
