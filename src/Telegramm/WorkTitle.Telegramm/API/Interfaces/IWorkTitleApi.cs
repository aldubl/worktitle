using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Telegramm.DomainModels;

namespace WorkTitle.Telegramm.API.Interfaces
{
    internal interface IWorkTitleApi
    {
        Task<User> GetUserByChatIdAsync(long chatId);
    }
}
