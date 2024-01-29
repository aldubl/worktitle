using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.Abstract.Interfaces
{
    internal interface IReceiverService
    {
        Task ReceiveAsync(CancellationToken stoppingToken);
    }
}
