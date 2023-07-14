using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.ProductDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
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
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            var createdProduct = _productService.AddProduct(product);
            return CreatedAtRoute("GetProduct", new { productId = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public ActionResult<ProductDTO> UpdateProductStock (ProductStockDTO newStock, int productId) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            _productService.UpdateProductStock(newStock.Stock, productId);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            _productService.DeleteProduct(productId);
            return NoContent();
        }
    }
}
