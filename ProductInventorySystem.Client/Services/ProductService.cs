using ProductInventorySystem.Client.Models;
using System.Net.Http.Json;

namespace ProductInventorySystem.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddStockAsync(StockRequest stock)
        {
            var response = await _http.PostAsJsonAsync("api/stock/add", stock);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveStockAsync(StockRequest stock)
        {
            var response = await _http.PostAsJsonAsync("api/stock/remove", stock);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateProductAsync(ProductRequest product)
        {
            var response = await _http.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<ProductRequest>> GetProductsAsync()
        {
            var products = await _http.GetFromJsonAsync<List<ProductRequest>>("api/products");
            return products ?? new List<ProductRequest>();
        }
    }
}
