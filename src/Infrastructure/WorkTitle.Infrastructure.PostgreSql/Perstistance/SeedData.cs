using WorkTitle.Domain.Entities;

namespace WorkTitle.Infrastructure.Perstistance
{
    /// <summary>
    /// Gets the initial roles for seed data.
    /// </summary>
    public static class SeedData
    {
        internal static IEnumerable<Role> Roles { get; }

        static SeedData()
        {
            Roles = new List<Role>()
            {
                new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Administrator",
                Description = "System administrator with full access and control.",
            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "User",
                Description = "User with standard permissions."
            },
            new Role()
            {
                Id = Guid.Parse("73745220-8b23-445c-83b1-ae3662dce2b2"),
                Name = "Guest",
                Description = "Limited access guest account."
            }};
        }
    }
}