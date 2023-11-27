using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Domain.EntitiesDto
{
    public sealed class ProductDto : BaseEntityDto
    {
        public string? Name { get; set; }

        public string? Url { get; set; }

        public decimal? LastPrice { get; set; }

        public short? LastScore { get; set; }

        public short? Priority { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Description { get; set; }

        public short? Vote { get; set; }

        public bool IsMined { get; set; }

        public decimal? Fullness { get; set; }

        public Guid ListId { get; set; }

        public byte[]? Image { get; set; }

        public WishList? List { get; set; }
    }
}
