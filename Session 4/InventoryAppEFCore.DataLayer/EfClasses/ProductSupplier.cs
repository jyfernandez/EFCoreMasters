namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public byte Order { get; set; }

        //relationships
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
    }
}