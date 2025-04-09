namespace ProductInventorySystem.API.Models.DTOs
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string HSNCode { get; set; }
        public decimal TotalStock { get; set; }
        public List<VariantDto> Variants { get; set; }
    }
}
