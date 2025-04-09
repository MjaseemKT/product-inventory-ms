using ProductInventorySystem.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductInventorySystem.Client.Services
{
    public interface IProductService
    {
        Task AddStockAsync(StockRequest stock);
        Task RemoveStockAsync(StockRequest stock);
        Task CreateProductAsync(ProductRequest product);
        Task<List<ProductRequest>> GetProductsAsync();
    }
}
