using AutoMapper;
using BackendEcommerce.Models;
using System.Runtime.InteropServices;

namespace BackendEcommerce.Dto.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
