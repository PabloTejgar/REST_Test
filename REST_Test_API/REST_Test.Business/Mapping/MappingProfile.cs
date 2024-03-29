﻿using AutoMapper;
using REST_Test.Model.Models;
using REST_Test.Business.DTO;

namespace REST_Test.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, UserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}