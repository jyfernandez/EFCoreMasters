﻿using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            var products = await _appDbContext.Products.ToListAsync();

            if (products != null)
            {
                return products.Select(p => new ProductDto(p.Id, p.Name, p.ShopId)).ToList();
            }

            return null;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = await _appDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                return new ProductDto(product.Id, product.Name, product.ShopId);
            }

            return null;
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            var product = new Product
            {
                Name = productForCreation.Name,
                ShopId = productForCreation.ShopId
            };

            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            
            return product.Id;
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = await _appDbContext.Products.SingleOrDefaultAsync(p => p.Id == productForUpdate.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product is not found");
            }

            product.Name = productForUpdate.Name;
            product.ShopId = productForUpdate.ShopId;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var product = await _appDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            
            if (product == null)
            {
                throw new KeyNotFoundException("Product is not found");
            }

            _appDbContext.Remove(product);

            await _appDbContext.SaveChangesAsync();

        }

    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}