using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Application.RoleService.CommandHandlers
{
    public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleAsyncCommand, Guid>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Guid> Handle(DeleteRoleAsyncCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Role)} with this id: {request.Id}");

            _roleRepository.Delete(existRole);
            await _roleRepository.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
