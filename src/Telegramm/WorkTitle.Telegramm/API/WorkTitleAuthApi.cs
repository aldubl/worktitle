using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;
using WorkTitle.Telegramm.API.Interfaces;

namespace WorkTitle.Telegramm.API
{
    internal sealed class WorkTitleAuthApi : IWorkTitleAuthApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _url;
        private readonly string _email;
        private readonly string _password;

        public WorkTitleAuthApi(ILogger<WorkTitleAuthApi> logger, string url, string email, string password)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _url = url;
            _email = email;
            _password = password;
        }

        public async Task<string> GetToken()
        {
            _logger.LogDebug("GetToken BEGIN");
            try
            {
                string responseBody;
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), _url + "/User/login"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    request.Content = new StringContent(JsonConvert.SerializeObject(new UserLogin() { Email = _email, Password = _password }));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");                    

                    var response = await _httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                }                                

                var obj = JObject.Parse(responseBody);

                string token = obj.SelectToken("token")!.Value<string>("token")!;
                
                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
                return "";
            }
            finally
            {
                _logger.LogDebug("GetToken END");
            }

        }
    }

    file sealed class UserLogin
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
