using AutoMapper;
using REST_Test.Model.Models;
using REST_Test.Business.DTO;

namespace BrandApplication.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}