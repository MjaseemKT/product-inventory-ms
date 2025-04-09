using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.DTOs
{
    public class AddStockRequest
    {
        [Required(ErrorMessage = "VariantCombination is required")]
        public string VariantCombination { get; set; }  // Size=M , Color=Red

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }

    }
}
