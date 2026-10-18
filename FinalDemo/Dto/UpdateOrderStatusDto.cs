using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class UpdateOrderStatusDto
    {
        [Required]
        [RegularExpression("^(Pending|Completed|Cancelled)$")]

        public string Status { get; set; }
    }
}
