﻿using Microsoft.EntityFrameworkCore;
using Shop.API.Data.Interfaces;
using Shop.API.DBContexts;
using Shop.API.Entities;

namespace Shop.API.Data.Implementations
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }

        public void AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null) 
                _context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(p => p.Category).ToList();
        }

        public Product? GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        //public void UpdateProduct(Product productToUpdate)
        //{
        //    _context.Entry(productToUpdate).State = EntityState.Modified;
        //}
    }
}
