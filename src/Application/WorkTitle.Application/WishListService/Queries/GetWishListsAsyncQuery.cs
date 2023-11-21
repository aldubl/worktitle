using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.WishListService.Queries
{
    public sealed record GetWishListsAsyncQuery : IRequest<IEnumerable<WishListDto>>;
}
