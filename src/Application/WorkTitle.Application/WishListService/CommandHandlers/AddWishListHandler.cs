using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.WishListService.Commands;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.CommandHandlers
{
    public sealed class AddWishListHandler : IRequestHandler<AddWishListAsyncCommand, WishListDto>
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public AddWishListHandler(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<WishListDto> Handle(AddWishListAsyncCommand request, CancellationToken cancellationToken)
        {
            _wishListRepository.Add(_mapper.Map<WishList>(request.WishList));
            await _wishListRepository.SaveChangesAsync(cancellationToken);

            return request.WishList;
        }
    }
}
