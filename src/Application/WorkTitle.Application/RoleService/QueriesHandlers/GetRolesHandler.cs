using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Queries;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.RoleService.QueriesHandlers
{
    public sealed class GetRolesHandler : IRequestHandler<GetRolesAsyncQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRolesHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetRolesAsyncQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Select(_mapper.Map<RoleDto>);
        }
    }
}
