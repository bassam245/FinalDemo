using FinalDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalDemo.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
   

        public DateTime OrderDate { get; set; }


        public string Status { get; set; }
       


        public decimal TotallAmount { get; set; }

        public int Sum { get; set; }

        public int userid { get; set; }

        [JsonIgnore]
        public ICollection<OrderItem> items { get; set; }

        
    }
}
