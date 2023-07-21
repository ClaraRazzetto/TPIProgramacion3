using Shop.API.Entities;
using Shop.API.Models.ProductDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface IProductService
    {
        public ProductDTO? GetProductById(int productId);
        public IEnumerable<ProductDTO> GetAllProducts();
        public ProductDTO AddProduct(ProductToCreateDTO productToCreateDTO);
        public void UpdateProductStock(int newStock, int productId);
        public void DeleteProduct(int productId);
        public bool VerificateProduct(int productid, int requiredStock);
    }
}
