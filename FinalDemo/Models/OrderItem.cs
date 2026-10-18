using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalDemo.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

      

        [Required]
        [Range(0.01,1000000)]

        public decimal unitprice { get; set; }

        [Required]

        [Range(1,1000)]
        public int quantity { get; set; }

        public Order order { get; set; }
        [Required]
        [ForeignKey("order")]
        public int orderId { get; set; }
        public Product product  { get; set; }
        [Required]
        [ForeignKey("product")]
        public int productid { get; set; }

    }
}
