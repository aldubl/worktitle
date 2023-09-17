
namespace WorkTitle.Api.Models
{
    /// <summary>
    /// Internal model for representing a role.
    /// </summary>
    public sealed class RoleModel
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        public string? Description { get; set; }
    }
}
