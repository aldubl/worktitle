using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Telegramm.API.Interfaces;
using WorkTitle.Telegramm.DomainModels;

namespace WorkTitle.Telegramm.API
{
    internal sealed class WorkTitleApi : IWorkTitleApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _url;
        private readonly IWorkTitleAuthApi _authApi;

        public WorkTitleApi(ILogger<WorkTitleApi> logger, string url, IWorkTitleAuthApi authApi)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _url = url;
            _authApi = authApi;
        }

        public async Task<User> GetUserByChatIdAsync(long chatId)
        {
            await SetToken();

            string body;

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), _url + "/api/Users/chatId/" + chatId))
            {
                request.Headers.TryAddWithoutValidation("accept", "text/plain");

                var response = await _httpClient.SendAsync(request);
                body = await response.Content.ReadAsStringAsync();
            }

            var user = JsonConvert.DeserializeObject<User>(body);

            return user!;
        }

        public async Task<User> RegisterUserAsync(UserModel user)
        {
            return await PostExecute<UserModel, User>(user, "/api/Users");
        }

        public async Task<Product> AddSimpleProductAsync(ProductSimpleModel product)
        {
            return await PostExecute<ProductSimpleModel, Product>(product, "/api/Products/AddSimpleProduct");
        }

        private async Task<T2> PostExecute<T1, T2>(T1 value, string path)
        {
            await SetToken();

            string body;

            using (var request = new HttpRequestMessage(new HttpMethod("POST"), _url + path))
            {
                request.Headers.TryAddWithoutValidation("accept", "text/plain");

                request.Content = new StringContent(JsonConvert.SerializeObject(value));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response = await _httpClient.SendAsync(request);
                body = await response.Content.ReadAsStringAsync();
            }

            var userOut = JsonConvert.DeserializeObject<T2>(body);

            return userOut!;
        }

        private async Task SetToken()
        {
            var token = await _authApi.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
