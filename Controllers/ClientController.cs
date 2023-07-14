using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.ClientDTOs;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<ICollection<ClientDTO>> GetAllClients()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<ClientDTO> GetClientById(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet("{id}/GetSaleOrders")]
        public ActionResult<ICollection<SaleOrderDTO>> GetClientSaleOrders (int id)
        {
            var saleOrders = _clientService.GetClientSaleOrders(id);
            return Ok(saleOrders);
        }

        [HttpPost]
        public ActionResult<ClientDTO> AddClient(ClientToCreateDTO clientToCreate)
        {
            var createdClient = _clientService.AddClient(clientToCreate);
            return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        public ActionResult UpdateClient(ClientToUpdateDTO clientToUpdate, int id)
        {
            _clientService.UpdateClient(clientToUpdate, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

    }
}
