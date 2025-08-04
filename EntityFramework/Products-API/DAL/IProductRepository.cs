using Products_API.Models;
namespace Products_API.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int productId);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);

    }
}