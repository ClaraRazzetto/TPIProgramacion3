using AutoMapper;
using Shop.API.Entities;
using Shop.API.Models.SaleOrderDTOs;

namespace Shop.API.AutoMapperProfiles
{
    public class SaleOrderProfile : Profile
    {
        public SaleOrderProfile() 
        { 
            //Mapeo la entidad al DTO
            CreateMap<SaleOrder, SaleOrderDTO>();
            CreateMap<SaleOrderToCreateDTO, SaleOrder>();
            CreateMap<SaleOrder, SaleOrderStatusDTO>();
        }
    }
}
