using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.WishListService.Queries;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.QueriesHandlers
{
    public sealed class GetWishListsHandler : IRequestHandler<GetWishListsAsyncQuery, IEnumerable<WishListDto>>
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public GetWishListsHandler(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WishListDto>> Handle(GetWishListsAsyncQuery request, CancellationToken cancellationToken)
        {
            var wishLists = await _wishListRepository.GetAllAsync();
            return wishLists.Select(_mapper.Map<WishListDto>);
        }
    }
}
