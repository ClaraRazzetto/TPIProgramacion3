using AutoMapper;
using Shop.API.Entities;
using Shop.API.Models.AdminDTOs;

namespace Shop.API.AutoMapperProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile() 
        {
            CreateMap<AdminToCreateDTO, Admin>();
            CreateMap<AdminToUpdateDTO, Admin>();

            CreateMap<User, AdminDTO>();
        }
    }
}
