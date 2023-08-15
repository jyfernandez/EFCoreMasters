using InventoryAppEFCore.DataLayer.Models.Entities;
namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
    }
}
