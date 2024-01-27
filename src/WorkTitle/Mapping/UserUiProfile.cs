using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.User;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Mapping
{
    internal sealed class UserUiProfile : Profile
    {
        public UserUiProfile()
        {
            CreateMap<UserDto, UserResponse>();
            CreateMap<UserDto, UserResponseShort>();
                
            CreateMap<UserDto, UserModel>();

            CreateMap<UserModel, UserDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.PhotoUrl, map => map.Ignore())
                .ForMember(x => x.DefaultListId, map => map.Ignore())
                .ForMember(x => x.DefaultList, map => map.Ignore())
                .ForMember(x => x.Lists, map => map.Ignore());
            CreateMap<UserResponse, UserDto>();
            CreateMap<UserResponseShort, UserDto>()
                .ForMember(x => x.DefaultList, map => map.Ignore())
                .ForMember(x => x.Lists, map => map.Ignore());


        }
    }
}
