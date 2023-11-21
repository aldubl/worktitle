using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.Commands
{
    public sealed record UpdateWishListAsyncCommand(Guid Id, WishListDto WishList) : IRequest<WishListDto>;
}
