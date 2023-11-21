using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.WishListService.Commands;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Application.RoleService.CommandHandlers
{
    public sealed class DeleteWishListHandler : IRequestHandler<DeleteWishListAsyncCommand, Guid>
    {
        private readonly IWishListRepository _wishListRepository;

        public DeleteWishListHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<Guid> Handle(DeleteWishListAsyncCommand request, CancellationToken cancellationToken)
        {
            var existWishList = await _wishListRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(WishList)} with this id: {request.Id}");

            _wishListRepository.Delete(existWishList);
            await _wishListRepository.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
