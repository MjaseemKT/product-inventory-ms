using System.ComponentModel.DataAnnotations;
namespace ProductInventorySystem.API.Models.Entities;
    public class VariantRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public List<string> Options { get; set; }
}
