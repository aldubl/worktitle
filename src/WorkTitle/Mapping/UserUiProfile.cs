using AutoMapper;
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
            CreateMap<UserModel, UserDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.Lists, map => map.Ignore());
        }
    }
}
