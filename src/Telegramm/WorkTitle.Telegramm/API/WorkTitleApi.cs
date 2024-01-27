using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Telegramm.API.Interfaces;
using WorkTitle.Telegramm.DomainModels;

namespace WorkTitle.Telegramm.API
{
    internal class WorkTitleApi : IWorkTitleApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _url;

        public WorkTitleApi(ILogger logger, string url)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _url = url;
        }

        public Task<User> GetUserByChatIdAsync(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
