namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductDTO> ProductsLink { get; set; }
    }
}
