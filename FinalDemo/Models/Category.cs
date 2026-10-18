using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
   

        public string Description { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
