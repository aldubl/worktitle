using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.RoleService.CommandHandlers
{
    public sealed class AddRoleHandler : IRequestHandler<AddRoleAsyncCommand, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public AddRoleHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(AddRoleAsyncCommand request, CancellationToken cancellationToken)
        {
            _roleRepository.Add(_mapper.Map<Role>(request.Role));
            await _roleRepository.SaveChangesAsync(cancellationToken);

            return request.Role;
        }
    }
}
