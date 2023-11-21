using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.WishListService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.QueriesHandlers
{
    public sealed class GetWishListByIdHandler : IRequestHandler<GetWishListByIdAsyncQuery, WishListDto>
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;
        public GetWishListByIdHandler(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<WishListDto> Handle(GetWishListByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var existWishList = await _wishListRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(WishList)} with this id: {request.Id}");

            return _mapper.Map<WishListDto>(existWishList);
        }
    }
}
