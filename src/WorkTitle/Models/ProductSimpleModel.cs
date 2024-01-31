using System.ComponentModel.DataAnnotations;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.Models
{
    public sealed class ProductSimpleModel
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required]
        public required string Name { get; set; }

        [Required]
        public required Guid ListId { get; set; }

    }
}
