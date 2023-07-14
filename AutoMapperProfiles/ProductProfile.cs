using AutoMapper;
using Shop.API.Entities;
using Shop.API.Models.ProductDTOs;

namespace Shop.API.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductToCreateDTO, Product>();
        }
    }
}
