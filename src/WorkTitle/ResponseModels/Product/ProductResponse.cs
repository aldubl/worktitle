using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.Product
{
    internal sealed record ProductResponse(
        Guid Id,
        string? Name,
        string? Url,
        decimal? LastPrice,
        short? LastScore,
        short? Priority,
        string? PhotoUrl,
        string? Description,
        short? Vote,
        bool IsMined,
        decimal? Fullness,
        Guid ListId,
        byte[]? Image,
        Domain.Entities.WishList? List);
}
