using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Telegramm.Abstract.Interfaces;
using WorkTitle.Telegramm.Abstract;

namespace WorkTitle.Telegramm.Services
{
    internal class PollingService : PollingServiceBase<ReceiverService>
    {
        public PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
            : base(serviceProvider, logger)
        {
        }
    }
}
