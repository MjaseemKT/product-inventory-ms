using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.DTOs
{
    public class RemoveStockRequest
    {
        [Required(ErrorMessage = "VariantCombination is required")]
        public string VariantCombination { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }
    }
}
