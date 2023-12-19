using Microsoft.AspNetCore.Identity;

namespace WebApiJwtAuthentication.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name) 
        {
            Name = name;
        }
    }
}
