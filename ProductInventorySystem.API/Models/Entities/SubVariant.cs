using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.API.Models.Entities
{
    public class SubVariant
    {

        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        public Variant Variant { get; set; }
    }
}
