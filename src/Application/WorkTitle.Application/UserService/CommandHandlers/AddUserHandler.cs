using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Application.UserService.Commands;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;
using WorkTitle.Helpers;

namespace WorkTitle.Application.UserService.CommandHandlers
{
    public sealed class AddUserHandler : IRequestHandler<AddUserAsyncCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public AddUserHandler(IUserRepository userRepository, IWishListRepository wishListRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _wishListRepository = wishListRepository;
        }

        public async Task<UserDto> Handle(AddUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var wishListId = _wishListRepository.Add(_mapper.Map<WishList>(DefaultValue.GetDefaultWishList())).Id;
            
            request.User.DefaultListId = wishListId;

            _userRepository.Add(_mapper.Map<User>(request.User));
            await _userRepository.SaveChangesAsync(cancellationToken);

            return request.User;
        }
    }
}
