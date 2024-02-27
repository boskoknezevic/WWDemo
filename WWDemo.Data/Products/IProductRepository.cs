using WWDemo.Models;

namespace WWDemo.Data.Products
{
    public interface IProductRepository
    {
        Task<List<Product?>> GetAllProducts();

        Task<Product?> GetProductById(Guid productId);

        Task<Product?> AddProduct(Product product);

        Task<Product?> UpdateProduct(Product product);
        Task<Product?> GetProductBySerialNumber(string? SerialNumber);
        Task DeleteProductBySerialNumber(string? SerialNumber);
    }
}
