namespace ProductInventorySystem.Client.Models
{
    public class ProductRequest
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; } 
        public Guid CreatedUserId { get; set; }
        public string HsnCode { get; set; }
        public List<VariantRequest> Variants { get; set; }
    }

    public class VariantRequest
    {
        public string Name { get; set; }
        public List<string> Options { get; set; }
    }

}
