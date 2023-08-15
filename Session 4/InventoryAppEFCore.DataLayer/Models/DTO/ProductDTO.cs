using InventoryAppEFCore.DataLayer.Models.Entities;

namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public PriceOfferDTO Promotion { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public ICollection<TagDTO> Tags { get; set; }
        public ICollection<ProductSupplierDTO> SuppliersLink { get; set; }
        public int LineItemId { get; set; }
        public LineItemDTO LineItems { get; set; }
    }
}
