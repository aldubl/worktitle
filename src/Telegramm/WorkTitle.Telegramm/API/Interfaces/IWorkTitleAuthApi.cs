using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.API.Interfaces
{
    internal interface IWorkTitleAuthApi
    {
        Task<string> GetToken();
    }
}
