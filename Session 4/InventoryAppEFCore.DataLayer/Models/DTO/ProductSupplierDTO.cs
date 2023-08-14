using InventoryAppEFCore.DataLayer.Models.Entities;

namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class ProductSupplierDTO
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public byte Order { get; set; }
        public SupplierDTO Supplier { get; set; }
        public ProductDTO Product { get; set; }
    }
}
