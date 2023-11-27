using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Application.WishListService.Commands
{
    public sealed record DeleteWishListAsyncCommand(Guid Id) : IRequest<Guid>;
}
