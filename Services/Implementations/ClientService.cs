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

        public ICollection<ClientDTO> GetAllClients()
        {
            var clients = _userRepository.GetAllUsers("Client");
            return _mapper.Map<ICollection<ClientDTO>>(clients);
        }
        public ClientDTO GetClientById(int userId)
        {
            var client = _userRepository.GetUserById(userId, "Client");
            return _mapper.Map<ClientDTO>(client);
        }
       
        public ClientDTO AddClient(ClientToCreateDTO clientToCreateDTO)
        {
            var newClient = _mapper.Map<Client>(clientToCreateDTO);
            _userRepository.AddUser(newClient);
            _userRepository.SaveChanges();
            return _mapper.Map<ClientDTO>(newClient);
        }
        public void UpdateClient(ClientToUpdateDTO clientToUpdateDTO, int clientId)
        {
            var clientToUpdate = _userRepository.GetUserById(clientId, "Client");
            _mapper.Map(clientToUpdateDTO, clientToUpdate);
            _userRepository.UpdateUser(clientToUpdate);
            _userRepository.SaveChanges();
        }

        public ICollection<SaleOrderDTO> GetClientSaleOrders(int clientId)
        {
            var saleOrders = _clientRepository.GetClientSaleOrders(clientId);
            return _mapper.Map<ICollection<SaleOrderDTO>>(saleOrders);
        }
    }
}
