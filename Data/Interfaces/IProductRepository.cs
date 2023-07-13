using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface IProductRepository : IRepository
    {
        //Traer todos los productos
        public IEnumerable<Product> GetAllProducts();
        //Traer producto por id
        public Product? GetProductById(int productId);
        //Agregar un nuevo producto
        public void AddProduct(Product newProduct);
        //Agregar un nuevo producto
        public void DeleteProduct(int productId);
        //Agregar un nuevo producto
        
        //public void UpdateProduct(Product productToUpdate);
    }
}
