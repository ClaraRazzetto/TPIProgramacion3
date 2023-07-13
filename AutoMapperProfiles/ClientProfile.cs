using AutoMapper;
using Shop.API.Entities;
using Shop.API.Models.ClientDTOs;

namespace Shop.API.AutoMapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientToCreateDTO, Client>();
            CreateMap<ClientToUpdateDTO, Client>();
        }
    }
}
