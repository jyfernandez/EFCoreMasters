using AutoMapper;
using InventoryAppEFCore.DataLayer.Models.Entities;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.Services.Interfaces;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.DataLayer.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.Services
{
    public class InventoryAppService : IInventoryAppService
    {
        private readonly InventoryAppEfCoreContext _appDbContext;
        private readonly IMapper _mapper;
        public InventoryAppService(InventoryAppEfCoreContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var product = await _appDbContext.Products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return product;
        }
    }
}