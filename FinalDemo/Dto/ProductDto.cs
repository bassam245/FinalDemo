using FinalDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalDemo.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]


        public string Description { get; set; }

        [Required]
        [Range(0.01, 100000)]

        public decimal price { get; set; }

        [Required]

        [Range(1, 100000)]
        public int stockquantity { get; set; }

       
        [Required]
     
        public int categoryId { get; set; }
    }
}
