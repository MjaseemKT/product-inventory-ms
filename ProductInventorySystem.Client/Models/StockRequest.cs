namespace ProductInventorySystem.Client.Models
{
    public class StockRequest
    {
        public Guid ProductId { get; set; }
        public Dictionary<string, string> VariantCombination { get; set; }
        public int Quantity { get; set; }
    }
}
