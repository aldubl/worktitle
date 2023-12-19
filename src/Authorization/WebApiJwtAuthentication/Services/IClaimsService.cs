using System.Security.Claims;
using WebApiJwtAuthentication.Models;

namespace WebApiJwtAuthentication.Services
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(ApplicationUser user);
    }
}
