using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Application.RoleService.Commands
{
    public sealed record DeleteRoleAsyncCommand(Guid Id) : IRequest<Guid>;
}
