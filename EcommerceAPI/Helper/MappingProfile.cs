using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Models;

namespace EcommerceAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
