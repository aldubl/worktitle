using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.RoleService.QueriesHandlers
{
    public sealed class GetRoleByIdHandler : IRequestHandler<GetRoleByIdAsyncQuery, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetRoleByIdHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetRoleByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var existRole = await _roleRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Role)} with this id: {request.Id}");

            return _mapper.Map<RoleDto>(existRole);
        }
    }
}
