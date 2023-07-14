using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface IProductRepository : IRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product? GetProductById(int productId);
        public void AddProduct(Product newProduct);
        public void DeleteProduct(int productId);  
    }
}
