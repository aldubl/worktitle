
using System.ComponentModel.DataAnnotations;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.Models
{
    /// <summary>
    /// Internal model for representing a role.
    /// </summary>
    public sealed class UserModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        public required string Name { get; set; }
        //public string? Login { get; set; }

        //public string? PhotoUrl { get; set; }

        [Required]
        public required long ChatId { get; set; }

        [Required]
        public required string Email { get; set; }

    }
}
