using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApiJwtAuthentication.Services
{
    public interface IJwtTokenService
    {
        JwtSecurityToken GetJwtToken(List<Claim> userClaims);
        bool ValidateJwtToken(string token);
    }
}
