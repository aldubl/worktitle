using AutoMapper;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.Product;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Mapping
{
    internal sealed class ProductUiProfile : Profile
    {
        public ProductUiProfile()
        {
            CreateMap<ProductDto, ProductResponse>();
            CreateMap<ProductDto, ProductResponseShort>();
            CreateMap<ProductDto, ProductModel>();

            CreateMap<ProductModel, ProductDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.Url, map => map.Ignore())
                .ForMember(x => x.ListId, map => map.Ignore())
                .ForMember(x => x.List, map => map.Ignore());
            CreateMap<ProductResponse, ProductDto>();
            CreateMap<ProductResponseShort, ProductDto>()
                .ForMember(x => x.Url, map => map.Ignore())
                .ForMember(x => x.ListId, map => map.Ignore());


        }
    }
}
