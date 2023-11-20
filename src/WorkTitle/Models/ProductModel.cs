using System.ComponentModel.DataAnnotations;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.Models
{
    public sealed class ProductModel
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required]
        public string? Name { get; set; }

        public decimal? LastPrice { get; set; }

        public short? LastScore { get; set; }

        public short? Priority { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Description { get; set; }

        public short? Vote { get; set; }

        public bool IsMined { get; set; }

        public decimal? Fullness { get; set; }

        public byte[]? Image { get; set; }

    }
}
