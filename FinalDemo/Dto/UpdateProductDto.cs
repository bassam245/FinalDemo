using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class UpdateProductDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]


        public string Description { get; set; }

        [Required]
        [Range(0.01, 100000)]

        public decimal price { get; set; }
    }
}
