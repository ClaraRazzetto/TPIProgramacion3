using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.ProductDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ICollection<ProductDTO>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        [AllowAnonymous]
        public ActionResult<ProductDTO> GetProduct(int productId) 
        {
            var product = _productService.GetProductById(productId);
            if(product == null) 
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDTO> AddProduct(ProductToCreateDTO product) 
        {
            var createdProduct = _productService.AddProduct(product);
            return CreatedAtRoute("GetProduct", new { productId = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public ActionResult<ProductDTO> UpdateProductStock (ProductStockDTO newStock, int productId) 
        {
            _productService.UpdateProductStock(newStock.Stock, productId);
            return NoContent();
        }

        [HttpPut("/DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }

        
    }
}
