using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.DTOs
{
    public class CreateUserRequest
    {

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
