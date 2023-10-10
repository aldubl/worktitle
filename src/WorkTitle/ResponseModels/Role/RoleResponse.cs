using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.Role
{
    internal sealed record RoleResponse(
        Guid Id,
        string Name,
        string Description,
        ICollection<WorkTitle.Domain.Entities.User> Users);
}
