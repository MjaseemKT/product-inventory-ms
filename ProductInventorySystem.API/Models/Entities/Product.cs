using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductInventorySystem.API.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        [ForeignKey("CreatedUser")]
        public Guid CreatedUserId { get; set; }

        public AppUser CreatedUser { get; set; }

        public bool IsFavourite { get; set; }

        public bool Active { get; set; }

        [MaxLength(100)]
        public string HSNCode { get; set; }

        [Precision(18, 4)]
        public decimal TotalStock { get; set; }

        public ICollection<Variant> Variants { get; set; }

        public ICollection<Stock> Stocks { get; set; }

    }
}
