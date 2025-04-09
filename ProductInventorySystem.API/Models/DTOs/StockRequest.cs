using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.DTOs
{
    public class StockRequest
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Dictionary<string, string> VariantCombination { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Quantity { get; set; }
    }
}
