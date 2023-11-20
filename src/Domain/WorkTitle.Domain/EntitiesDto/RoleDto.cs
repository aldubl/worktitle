using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Domain.EntitiesDto
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a role.
    /// </summary>
    public sealed class RoleDto : BaseEntityDto
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of users associated with this role.
        /// </summary>
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
