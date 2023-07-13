using AutoMapper;
using Shop.API.Data.Implementations;
using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Models.AdminDTOs;
using Shop.API.Models.ClientDTOs;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class ClientService : UserService, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IUserRepository userRepository, IMapper mapper, IClientRepository clientRepository) : base(userRepository, mapper)
        {
            _clientRepository = clientRepository;
        }
        public ClientDTO GetClientById(int userId)
        {
            var client = _clientRepository.GetClientById(userId);
            return _mapper.Map<ClientDTO>(client);
        }
        public ICollection<ClientDTO> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            return _mapper.Map<ICollection<ClientDTO>>(clients);
        }
        public ClientDTO AddClient(ClientToCreateDTO clientToCreateDTO)
        {
            var newClient = _mapper.Map<Client>(clientToCreateDTO);
            _clientRepository.AddClient(newClient);
            _clientRepository.SaveChanges();
            return _mapper.Map<ClientDTO>(newClient);
        }
        public void UpdateClient(ClientToUpdateDTO clientToUpdateDTO, int clientId)
        {
            var clientToUpdate = _clientRepository.GetClientById(clientId);
            _mapper.Map(clientToUpdateDTO, clientToUpdate);
            _clientRepository.UpdateClient(clientToUpdate);
            _clientRepository.SaveChanges();
        }

        public ICollection<SaleOrderDTO> GetClientSaleOrders(int clientId)
        {
            var saleOrders = _clientRepository.GetClientSaleOrders(clientId);
            return _mapper.Map<ICollection<SaleOrderDTO>>(saleOrders);
        }
    }
}
