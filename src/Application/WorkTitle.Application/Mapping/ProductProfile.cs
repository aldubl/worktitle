using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.Mapping
{
    public sealed class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember is not null));
            CreateMap<Product, ProductDto>();
        }
    }
}
