using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.UserService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.UsersService.QueriesHandlers
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdAsyncQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(User)} with this id: {request.Id}");

            return _mapper.Map<UserDto>(existUser);
        }
    }
}
