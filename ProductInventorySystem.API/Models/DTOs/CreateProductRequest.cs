using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.Entities
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        [Required]
        public Guid CreatedUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string HSNCode { get; set; }

        public List<VariantRequest> Variants { get; set; }
    }
}
