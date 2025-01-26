using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BuyOrder
    {
        public Guid BuyOrderID { get; set; }

        [Required(ErrorMessage = "Stock Symbol is required.")]
        public string StockSymbol { get; set; }

        [Required(ErrorMessage = "Stock Name is required.")]
        public string StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "Quantity should be between 1 and 100000")]
        public uint Quantity { get; set; }

        [Range(1.00, 100000.00, ErrorMessage = "Price should be between 1 and 100000")]
        public double Price { get; set; }
    }
}
