using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.WishList
{
    internal sealed record WishListResponse(
        Guid Id,
        Guid? UserId,
        bool IsPublic,
        Guid? TypeId,
        bool IsGroup,
        short? NeedVotes,
        bool? IsShowMined,
        bool IsShowFullness,
        string? Name,
        byte[]? Image,
        ICollection<Domain.Entities.Product>? Products,
        ListType? Type,
        Domain.Entities.User? User,
        ICollection<Domain.Entities.User>? Users);
}
