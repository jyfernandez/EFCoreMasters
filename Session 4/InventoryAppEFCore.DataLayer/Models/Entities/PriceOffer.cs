using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.Models.Entities
{
    public class PriceOffer
    {
        [Key]
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }
        public string PromotinalText { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public string NewPriceText { get; set; }
        public string Currency { get; set; }

        //relationship---
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
    }
}
