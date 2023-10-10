using AutoMapper;
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
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.UserService.CommandHandlers
{
    public sealed class AddUserHandler : IRequestHandler<AddUserAsyncCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(AddUserAsyncCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Add(_mapper.Map<User>(request.User));
            await _userRepository.SaveChangesAsync(cancellationToken);

            return request.User;
        }
    }
}
