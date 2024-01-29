using AutoMapper;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.User;
using WorkTitle.Api.ResponseModels.WishList;
using WorkTitle.Domain.EntitiesDto;


namespace WorkTitle.Api.Mapping
{
    internal sealed class WishListUiProfile : Profile
    {
        public WishListUiProfile()
        {
            CreateMap<WishListDto, WishListResponse>();
            CreateMap<WishListDto, WishListResponseShort>();

            CreateMap<WishListDto, WishListModel>();

            CreateMap<WishListModel, WishListDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.UserId, map => map.Ignore())
                .ForMember(x => x.IsPublic, map => map.Ignore())
                .ForMember(x => x.TypeId, map => map.Ignore())
                .ForMember(x => x.IsGroup, map => map.Ignore())
                .ForMember(x => x.NeedVotes, map => map.Ignore())
                .ForMember(x => x.IsShowMined, map => map.Ignore())
                .ForMember(x => x.IsShowFullness, map => map.Ignore())
                .ForMember(x => x.Image, map => map.Ignore())
                .ForMember(x => x.Type, map => map.Ignore())
                .ForMember(x => x.User, map => map.Ignore())
                .ForMember(x => x.Products, map => map.Ignore())
                .ForMember(x => x.Users, map => map.Ignore());
            CreateMap<WishListResponse, WishListDto>();
            CreateMap<WishListResponseShort, WishListDto>()
                .ForMember(x => x.UserId, map => map.Ignore())
                //.ForMember(x => x.IsPublic, map => map.Ignore())
                .ForMember(x => x.TypeId, map => map.Ignore());
            //.ForMember(x => x.IsGroup, map => map.Ignore());
        }
    }
}
