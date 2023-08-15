using InventoryAppEFCore.DataLayer.Models.Entities;

namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class TagDTO
    {
        public string TagId { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}
