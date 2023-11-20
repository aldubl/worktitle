using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.UserService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.UserService.QueriesHandlers
{
    public sealed class GetUserByChatIdHandler : IRequestHandler<GetUserByChatIdAsyncQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByChatIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByChatIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var existUser = users.FirstOrDefault(u => u.ChatId == request.chatId) ??
                throw new KeyNotFoundException($"Not found {nameof(User)} with this chatId: {request.chatId}");

            return _mapper.Map<UserDto>(existUser);
        }
    }
}
