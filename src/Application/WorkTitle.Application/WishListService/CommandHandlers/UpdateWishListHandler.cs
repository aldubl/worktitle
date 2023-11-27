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
    public class UpdateWishListHandler : IRequestHandler<UpdateWishListAsyncCommand, WishListDto>
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public UpdateWishListHandler(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<WishListDto> Handle(UpdateWishListAsyncCommand request, CancellationToken cancellationToken)
        {
            var existWishList = await _wishListRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(WishList)} with this id: {request.Id}");

            _mapper.Map(request.WishList, existWishList).Id = request.Id;

            _wishListRepository.Update(_mapper.Map<WishList>(existWishList));
            await _wishListRepository.SaveChangesAsync(cancellationToken);

            return request.WishList;
        }
    }
}
