using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/saleOrder")]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;

        public SaleOrderController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<SaleOrderDTO> GetAllSaleOrders()
        {
            var saleOrders = _saleOrderService.GetAllSaleOrders();
            return Ok(saleOrders);
        }

        [HttpGet("{saleOrderId}", Name = "GetSaleOrder")]
        [Authorize(Roles = "Admin")]
        public ActionResult<SaleOrderDTO> GetSaleOrder(int saleOrderId)
        {
            var saleOrder = _saleOrderService.GetSaleOrder(saleOrderId);
            if (saleOrder == null)
                return NotFound();
            return Ok(saleOrder);
        }
        
        
        [HttpPost("/Create")]
        [Authorize(Roles = "Client")]
        public ActionResult AddSaleOrder(SaleOrderToCreateDTO saleOrderToCreateDTO)
        { 
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
                return Unauthorized();
            
            var createdSaleOrder = _saleOrderService.AddSaleOrder(saleOrderToCreateDTO, id);

            if (createdSaleOrder == null)
                return BadRequest();

            return CreatedAtRoute("GetSaleOrder", new { saleOrderId = createdSaleOrder.Id }, createdSaleOrder);

        }

        [HttpPut("{saleOrderId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<SaleOrderStatusDTO> ChangeSaleOrderStatus(int saleOrderId) 
        {
            var newStatus = _saleOrderService.UpdateSaleOrderStatus(saleOrderId);
            if(newStatus == null)
            {
                return NotFound();
            }
            return Ok(newStatus);
        }

        [HttpDelete("{saleOrderId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSaleOrder(int saleOrderId) 
        {  
            _saleOrderService.DeleteSaleOrder(saleOrderId);
            return NoContent();
        }

    }
}
