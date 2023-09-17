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
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleAsyncCommand, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(UpdateRoleAsyncCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Role)} with this id: {request.Id}");

            _mapper.Map(request.Role, existRole).Id = request.Id;

            _roleRepository.Update(_mapper.Map<Role>(existRole));
            await _roleRepository.SaveChangesAsync(cancellationToken);

            return request.Role;
        }
    }
}
