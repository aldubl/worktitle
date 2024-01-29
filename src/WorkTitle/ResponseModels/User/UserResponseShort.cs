using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.User
{
    internal sealed record UserResponseShort(
        Guid Id,
        string Name,
        //string? Login,
        string? PhotoUrl,
        long ChatId,
        string Email,
        Guid DefaultListId);
}
