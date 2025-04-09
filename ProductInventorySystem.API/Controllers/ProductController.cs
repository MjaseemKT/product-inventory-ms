using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventorySystem.API.Data;
using ProductInventorySystem.API.Models.DTOs;
using ProductInventorySystem.API.Models.Entities;

namespace ProductInventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductCode = request.ProductCode,
                ProductName = request.ProductName,
                ProductImage = request.ProductImage,
                CreatedUserId = request.CreatedUserId,
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow,
                HSNCode = request.HSNCode,
                IsFavourite = false,
                Active = true,
                Variants = request.Variants.Select(v => new Variant
                {
                    Name = v.Name,
                    Options = v.Options.Select(o => new SubVariant { Value = o }).ToList()
                }).ToList()
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(new { product.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products
          .Include(p => p.Variants)
          .ThenInclude(v => v.Options)
          .Select(p => new ProductListDto
          {
              Id = p.Id,
              ProductCode = p.ProductCode,
              ProductName = p.ProductName,
              HSNCode = p.HSNCode,
              TotalStock = p.TotalStock,
              Variants = p.Variants.Select(v => new VariantDto
              {
                  Name = v.Name,
                  Options = v.Options.Select(o => o.Value).ToList()
              }).ToList()
          })
          .ToListAsync();

            return Ok(products);
        }
    }
}
