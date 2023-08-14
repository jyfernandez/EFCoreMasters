using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        //relationships---
        public PriceOffer Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ICollection<ProductSupplier> SuppliersLink { get; set; }

        public bool IsDeleted { get; set; }
        public int LineItemId { get; set; }
        public LineItem LineItems { get; set; }

    }
}
