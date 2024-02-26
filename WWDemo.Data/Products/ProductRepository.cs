using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WWDemo.Models;

namespace WWDemo.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public Task<List<Product?>> GetAllProducts()
        {
            return Task.Run(() => GetQueryable().ToList());
        }

        public Task<Product?> GetProductById(Guid productId)
        {
            return GetQueryable().FirstOrDefaultAsync(x => x!.Id == productId);
        }

        public async Task<Product?> AddProduct(Product product)
        {
            var result = _apiDbContext.Products?.Add(product)!;

            await _apiDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var result = _apiDbContext.Products?.Update(product)!;

            await _apiDbContext.SaveChangesAsync();

            return result.Entity;
        }

        private IQueryable<Product?> GetQueryable()
        {
            var products = _apiDbContext.Products;

            return products;
        }

        public Task<Product?> GetProductBySerialNumber(string? SerialNumber)
        {
            return GetQueryable().FirstOrDefaultAsync(x => x!.SerialNumber == SerialNumber);
        }
    }
}
