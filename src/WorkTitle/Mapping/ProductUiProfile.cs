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

            CreateMap<ProductSimpleModel, ProductDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.Url, map => map.Ignore())
                .ForMember(x => x.LastPrice, map => map.Ignore())
                .ForMember(x => x.LastScore, map => map.Ignore())
                .ForMember(x => x.Priority, map => map.Ignore())
                .ForMember(x => x.PhotoUrl, map => map.Ignore())
                .ForMember(x => x.Description, map => map.Ignore())
                .ForMember(x => x.Vote, map => map.Ignore())
                .ForMember(x => x.IsMined, map => map.Ignore())
                .ForMember(x => x.Fullness, map => map.Ignore())
                .ForMember(x => x.Image, map => map.Ignore())
                .ForMember(x => x.List, map => map.Ignore());

            CreateMap<ProductModel, ProductDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.Url, map => map.Ignore())
                .ForMember(x => x.ListId, map => map.Ignore())
                .ForMember(x => x.List, map => map.Ignore());
            //CreateMap<ProductResponse, ProductDto>();
            //CreateMap<ProductResponseShort, ProductDto>()
            //    .ForMember(x => x.Url, map => map.Ignore())
            //    .ForMember(x => x.ListId, map => map.Ignore());
        }
    }
}
