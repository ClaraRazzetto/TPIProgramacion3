using Shop.API.Entities;
using Shop.API.Models.ProductDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface IProductService
    {
        public ProductDTO? GetProductById(int productId);
        public IEnumerable<ProductDTO> GetAllProducts();
        public ProductDTO? AddProduct(ProductToCreateDTO productToCreateDTO);
        public ProductDTO? UpdateProductStock(int newStock, int productId);
        public ProductDTO? DeleteProduct(int productId);
        public bool VerificateProduct(int productid, int requiredStock);
    }
}
