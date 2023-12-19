using BlazorAuthentication.Services;
using Common.DTO;
using System.Net.Http.Json;


namespace BlazorAuthentication
{
    public class AuthenticationHttpClient
    {
        private readonly ILogger<AuthenticationHttpClient> logger;
        private readonly HttpClient http;
		private readonly ITokenService tokenService;

		public AuthenticationHttpClient(ILogger<AuthenticationHttpClient> logger,
            HttpClient http/*, ITokenService tokenService*/)
        {
            this.logger = logger;
            this.http = http;
			//this.tokenService = tokenService;
		}

        public async Task<UserRegisterResultDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var response = await http.PostAsJsonAsync("user/register", userRegisterDTO);
                var result = await response.Content.ReadFromJsonAsync<UserRegisterResultDTO>();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return new UserRegisterResultDTO
                {
                    Succeeded = false,
                    Errors = new List<string>()
                    {
                        "Извините, на данный момент нам не удалось зарегистрировать вас. " +
                        "Пожалуйста, повторите попытку в ближайшее время."
                    }
                };
            }
        }


        public async Task<UserLoginResultDTO> LoginUser(UserLoginDTO userLoginDTO)
		{
			try
			{
				var response = await http.PostAsJsonAsync("user/login", userLoginDTO);
				var result = await response.Content.ReadFromJsonAsync<UserLoginResultDTO>();
				//await tokenService.SetToken(result.Token);
				return result;
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);

				return new UserLoginResultDTO
				{
					Succeeded = false,
					Message = "Извините, на данный момент нам не удалось авторизовать вас. " +
                        "Пожалуйста, повторите попытку в ближайшее время."
                };
			}
		}
	}
}