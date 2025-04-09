using Microsoft.EntityFrameworkCore;
using ProductInventorySystem.API.Models.Entities;

namespace ProductInventorySystem.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<SubVariant> VariantOptions { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasIndex(s => new { s.ProductId, s.VariantCombination })
                .IsUnique();
        }
    }
}
