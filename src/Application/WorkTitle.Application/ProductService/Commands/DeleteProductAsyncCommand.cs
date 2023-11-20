using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Application.ProductService.Commands
{
    public sealed record DeleteProductAsyncCommand(Guid Id) : IRequest<Guid>;
}
