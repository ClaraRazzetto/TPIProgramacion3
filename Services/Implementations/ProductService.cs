﻿using AutoMapper;
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
        public ProductDTO? AddProduct(ProductToCreateDTO productToCreateDTO)
        {
            if(productToCreateDTO.Stock >= 0) {
                var newProduct = _mapper.Map<Product>(productToCreateDTO);
                _productRepository.AddProduct(newProduct);
                _productRepository.SaveChanges();  
                return _mapper.Map<ProductDTO>(newProduct);
            }
            return null;
           
        }
        
        public ProductDTO? UpdateProductStock(int newStock, int productId)
        {
            var productToUpdate = _productRepository.GetProductById(productId);
            if(productToUpdate != null) 
            { 
                if(newStock  >= 0) { 
                productToUpdate.Stock = newStock;
                _productRepository.SaveChanges(); 
                } 
            } 
            return _mapper.Map<ProductDTO>(productToUpdate);
        }

        public ProductDTO DeleteProduct(int productId)
        {
            var productToUpdate = _productRepository.GetProductById(productId);
            if (productToUpdate != null)
            {
                productToUpdate.Status = Enums.ProductStatus.Eliminado;
                _productRepository.SaveChanges();
            }
            return _mapper.Map<ProductDTO>(productToUpdate);
        }
        
        public void RemoveStock (int quantity, Product productToRemoveFromStock)
        {
                productToRemoveFromStock.Stock -= quantity;
                _productRepository.SaveChanges();
        }

        public bool VerificateProduct (int productid, int quantity)
        {
            var product = _productRepository.GetProductById(productid);
            if (product == null)
                return false;
            if (quantity > 0 && product.Stock >= quantity)
            {
                RemoveStock(quantity, product);
                return true;
            }
            return false;
        }
    }
}
