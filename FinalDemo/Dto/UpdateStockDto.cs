using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Dto
{
    public class UpdateStockDto
    {
        [Range(1, 100000)]
        public int stockquantity { get; set; }
    }
}
