using AutoMapper;
using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Models.ProductDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public ProductDTO? GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return _mapper.Map<ProductDTO>(product);
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
           var products = _productRepository.GetAllProducts();

           return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public ProductDTO AddProduct(ProductToCreateDTO productToCreateDTO)
        {
            var newProduct = _mapper.Map<Product>(productToCreateDTO);
            
            _productRepository.AddProduct(newProduct);
            
            _productRepository.SaveChanges();

            return _mapper.Map<ProductDTO>(newProduct);
        }
        
        public void UpdateProduct(int newStock, int productId)
        {
            var productToUpdate = _productRepository.GetProductById(productId);
            productToUpdate.Stock = newStock;
            _productRepository.SaveChanges();
        }
        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
            _productRepository.SaveChanges();
        }
    }
}
