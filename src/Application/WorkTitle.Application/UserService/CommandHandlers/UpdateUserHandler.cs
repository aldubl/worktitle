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

namespace WorkTitle.Application.RoleService.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserAsyncCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(User)} with this id: {request.Id}");

            _mapper.Map(request.User, existUser).Id = request.Id;

            _userRepository.Update(_mapper.Map<User>(existUser));
            await _userRepository.SaveChangesAsync(cancellationToken);

            return request.User;
        }
    }
}
