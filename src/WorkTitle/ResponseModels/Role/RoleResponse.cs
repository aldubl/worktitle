using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.Role
{
    internal sealed record RoleResponse(
        Guid Id,
        string Name,
        string Description,
        ICollection<User> Users);
}
