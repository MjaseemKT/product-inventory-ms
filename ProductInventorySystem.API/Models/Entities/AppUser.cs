using System.ComponentModel.DataAnnotations;
namespace ProductInventorySystem.API.Models.Entities;
public class AppUser
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }
}
