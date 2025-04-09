using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.Entities
{
    public class Variant
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public ICollection<SubVariant> Options { get; set; }
    }


}
