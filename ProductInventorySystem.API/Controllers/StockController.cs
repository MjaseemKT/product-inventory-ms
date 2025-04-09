using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventorySystem.API.Data;
using ProductInventorySystem.API.Models.DTOs;
using ProductInventorySystem.API.Models.Entities;

namespace ProductInventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStock([FromBody] StockRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string key = string.Join(";", request.VariantCombination.Select(kv => $"{kv.Key}={kv.Value}"));

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == request.ProductId && s.VariantCombination == key);

            if (stock == null)
            {
                stock = new Stock
                {
                    ProductId = request.ProductId,
                    VariantCombination = key,
                    Quantity = request.Quantity
                };
                _context.Stocks.Add(stock);
            }
            else
            {
                stock.Quantity += request.Quantity;
            }

            var product = await _context.Products.FindAsync(request.ProductId);
            product.TotalStock += request.Quantity;

            await _context.SaveChangesAsync();
            return Ok(stock);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveStock([FromBody] StockRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string key = string.Join(";", request.VariantCombination.Select(kv => $"{kv.Key}={kv.Value}"));

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == request.ProductId && s.VariantCombination == key);

            if (stock == null || stock.Quantity < request.Quantity)
                return BadRequest("Not enough stock to remove.");

            stock.Quantity -= request.Quantity;

            var product = await _context.Products.FindAsync(request.ProductId);
            product.TotalStock -= request.Quantity;

            await _context.SaveChangesAsync();
            return Ok(stock);
        }
    }
}
