using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Application.UserService.Commands;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Application.RoleService.CommandHandlers
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserAsyncCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeleteUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(User)} with this id: {request.Id}");

            _userRepository.Delete(existUser);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
