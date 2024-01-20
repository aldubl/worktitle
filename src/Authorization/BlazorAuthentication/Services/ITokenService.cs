using Common.DTO;

namespace BlazorAuthentication.Services
{
    public interface ITokenService
    {
        Task<TokenDTO> GetToken();
        Task RemoveToken();
        Task SetToken(TokenDTO tokenDTO);
    }
}
