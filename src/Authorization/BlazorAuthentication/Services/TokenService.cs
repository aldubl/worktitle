using Blazored.LocalStorage;
using Common.DTO;

namespace BlazorAuthentication.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILocalStorageService localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task SetToken(TokenDTO tokenDTO)
        {
            await localStorageService.SetItemAsync("token", tokenDTO);
        }

        public async Task<TokenDTO> GetToken()
        {
            return await localStorageService.GetItemAsync<TokenDTO>("token");
        }

        public async Task RemoveToken()
        {
            await localStorageService.RemoveItemAsync("token");
        }
    }
}
