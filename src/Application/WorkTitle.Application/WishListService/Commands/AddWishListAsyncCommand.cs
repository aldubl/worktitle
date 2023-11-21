using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.Commands
{
    public sealed record AddWishListAsyncCommand(WishListDto WishList) : IRequest<WishListDto>;
}
