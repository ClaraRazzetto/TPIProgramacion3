using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/saleOrder")]
    [Authorize(Roles = ("Admin"))]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;

        public SaleOrderController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        [HttpGet]
        public ActionResult<SaleOrderDTO> GetAllSaleOrders()
        {
            var saleOrders = _saleOrderService.GetAllSaleOrders();
            return Ok(saleOrders);
        }

        [HttpGet("{saleOrderId}", Name = "GetSaleOrder")]
        public ActionResult<SaleOrderDTO> GetSaleOrder(int saleOrderId)
        {
            var saleOrder = _saleOrderService.GetSaleOrder(saleOrderId);
            if (saleOrder == null)
                return NotFound();
            return Ok(saleOrder);
        }

        [HttpPost("/Create")]
        [Authorize(Roles = "Client")]
        public ActionResult<SaleOrderDTO> AddSaleOrder(SaleOrderToCreateDTO saleOrderToCreateDTO)
        { 
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
                return Unauthorized();
         
            var createdSaleOrder = _saleOrderService.AddSaleOrder(saleOrderToCreateDTO, id);
            return CreatedAtRoute("GetSaleOrder", new { saleOrderId = createdSaleOrder.Id }, createdSaleOrder);
 
        }

        [HttpPut("{saleOrderId}")]
        public ActionResult ChangeSaleOrderStatus(int saleOrderId, SaleOrderStatusDTO newStatus) 
        {
            _saleOrderService.UpdateSaleOrderStatus(newStatus.Status, saleOrderId);
            return NoContent();
        }

        [HttpDelete("{saleOrderId}")]
        public ActionResult DeleteSaleOrder(int saleOrderId) 
        {  
            _saleOrderService.DeleteSaleOrder(saleOrderId);
            return NoContent();
        }

    }
}
