using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.Models.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ExcludeClass ExcludedClass { get; set; }

        //Relationships
        public ICollection<Product> ProductsLink { get; set; }
    }
}
