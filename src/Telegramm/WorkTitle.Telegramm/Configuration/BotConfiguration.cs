using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.Configuration
{
    internal sealed class BotConfiguration
    {
        public static readonly string Configuration = "BotConfiguration";

        public string BotToken { get; set; } = "";
    }
}
