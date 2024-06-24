using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Models;

namespace EcommerceAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserDtoNoPassword>();
            CreateMap<UserDtoNoPassword, User>();
            CreateMap<UserDto, User>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
