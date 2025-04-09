
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductInventorySystem.API.Models.Entities;
public class Stock
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public Guid ProductId { get; set; }

    public Product Product { get; set; }

    public string VariantCombination { get; set; } // E.g. "Size=M;Color=Red"
    [Precision(18, 4)]
    public decimal Quantity { get; set; }

    public bool IsAddition { get; set; } // true = purchase, false = sale
}
