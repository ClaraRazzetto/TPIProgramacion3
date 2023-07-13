using Shop.API.Entities;
using Shop.API.Models.ClientDTOs;
using Shop.API.Models.SaleOrderDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface IClientService : IUserService
    {
        ClientDTO GetClientById(int clientId);
        public ICollection<ClientDTO> GetAllClients();
        public ClientDTO AddClient(ClientToCreateDTO clientToCreateDTO);
        public void UpdateClient(ClientToUpdateDTO clientToUpdateDTO, int clietId);
        public ICollection<SaleOrderDTO> GetClientSaleOrders(int clientId);
    }
}
