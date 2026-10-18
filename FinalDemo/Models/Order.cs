using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
       
        public DateTime OrderDate { get; set; }

        [Required]
        [RegularExpression("^(Pending|Completed|Cancelled)$")]

        public string Status { get; set; }
        [Required]
     

        public decimal TotallAmount { get; set; }

        public User user { get; set; }
        [Required]
        [ForeignKey("user")]
        public int userid { get; set; }

        public ICollection<OrderItem> items { get; set; }
    }
}
