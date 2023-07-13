using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.ProductDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ICollection<ProductDTO>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<ProductDTO> GetProduct(int id) 
        {
            var product = _productService.GetProductById(id);
            if(product == null) 
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDTO> AddProduct(ProductToCreateDTO product) 
        {
            var createdProduct = _productService.AddProduct(product);
            return CreatedAtRoute("GetProduct", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}/UpdateStock")]
        public ActionResult<ProductDTO> UpdateProductStock (ProductStockDTO newStock, int id) 
        {
            _productService.UpdateProduct(newStock.Stock, id);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId) 
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }
    }
}
