using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.User
{
    internal sealed record UserResponse(
        Guid Id,
        string? Name,
        string? Login,
        string? PhotoUrl,
        string? ChatId,
        string Email,
        Guid? DefaultListId,
        WishList? DefaultList,
        ICollection<WishList>? Lists);
}
