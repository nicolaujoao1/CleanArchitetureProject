using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Mappings
{
    public class DomainToDTOMappingProfile:Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
