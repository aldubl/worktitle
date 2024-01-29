using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.User
{
    internal sealed record UserResponse(
        Guid Id,
        string Name,
        //string? Login,
        string? PhotoUrl,
        long ChatId,
        string Email,
        Guid DefaultListId,
        Domain.Entities.WishList DefaultList,
        ICollection<Domain.Entities.WishList> Lists);
}
