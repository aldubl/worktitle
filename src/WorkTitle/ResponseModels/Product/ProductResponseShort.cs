using System.Collections.Generic;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.ResponseModels.Product
{
    internal sealed record ProductResponseShort(
        Guid Id,
        string? Name,
        decimal? LastPrice,
        short? LastScore,
        short? Priority,
        string? PhotoUrl,
        string? Description,
        short? Vote,
        bool IsMined,
        decimal? Fullness,
        byte[]? Image,
        WishList? List
        );
    
    
}
