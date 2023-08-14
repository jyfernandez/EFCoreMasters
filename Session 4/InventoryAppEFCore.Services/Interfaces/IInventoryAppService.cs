using InventoryAppEFCore.DataLayer.Models.DTO;

namespace InventoryAppEFCore.Services.Interfaces
{
    public interface IInventoryAppService
    {
        Task<List<ProductDTO>> GetProducts();
    }
}
