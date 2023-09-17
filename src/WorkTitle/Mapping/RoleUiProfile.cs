using AutoMapper;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.Role;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Mapping
{
    internal sealed class RoleUiProfile : Profile
    {
        public RoleUiProfile()
        {
            CreateMap<RoleDto, RoleResponse>();
            CreateMap<RoleDto, RoleResponseShort>();
            CreateMap<RoleModel, RoleDto>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.Users, map => map.Ignore());
        }
    }
}
