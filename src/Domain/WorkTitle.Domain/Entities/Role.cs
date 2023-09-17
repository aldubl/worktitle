using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    /// <summary>
    /// Represents a role entity.
    /// </summary>
    public sealed class Role : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of users associated with this role.
        /// </summary>
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
