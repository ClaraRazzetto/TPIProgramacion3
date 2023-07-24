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

        [HttpPost("/CreateNewProduct")]
        public ActionResult AddProduct(ProductToCreateDTO product) 
        {
            var createdProduct = _productService.AddProduct(product);
            
            if (createdProduct == null)
                return BadRequest();

            return CreatedAtRoute("GetProduct", new { productId = createdProduct.Id }, createdProduct);
        }

        [HttpPut("/UpdateProductStock")]
        public ActionResult UpdateProductStock (ProductStockDTO newStock, int productId) 
        {
            var updatedProduct = _productService.UpdateProductStock(newStock.Stock, productId);
            
            if(updatedProduct == null)
                return BadRequest();

            return CreatedAtRoute("GetProduct", new { productId = updatedProduct.Id }, updatedProduct);
        }

        [HttpPut("/DeleteProduct")]
        public ActionResult DeleteProduct(int productId)
        {
            var deletedProduct =_productService.DeleteProduct(productId);
            
            if(deletedProduct == null)
                return BadRequest();

            return Ok();
        }

        
    }
}
