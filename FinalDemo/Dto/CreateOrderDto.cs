using FinalDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalDemo.Dto
{
    public class CreateOrderDto
    {
        [Required]

        public DateTime OrderDate { get; set; }

        [Required]
        [RegularExpression("^(Pending|Completed|Cancelled)$")]

        public string Status { get; set; }
        [Required]


        public decimal TotallAmount { get; set; }

    
        [Required]
      
        public int userid { get; set; }

    }
}
