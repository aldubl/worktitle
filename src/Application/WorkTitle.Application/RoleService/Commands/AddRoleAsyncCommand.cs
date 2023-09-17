using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.RoleService.Commands
{
    public sealed record AddRoleAsyncCommand(RoleDto Role) : IRequest<RoleDto>;
}
