using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Application.UserService.Commands
{
    public sealed record DeleteUserAsyncCommand(Guid Id) : IRequest<Guid>;
}
