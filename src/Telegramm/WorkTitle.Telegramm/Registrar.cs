using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using WorkTitle.Telegramm.Configuration;
using WorkTitle.Telegramm.Services;
using Microsoft.Extensions.Hosting;

namespace WorkTitle.Telegramm
{
    internal static class Registrar
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, HostBuilderContext context)
        {
            services.Configure<BotConfiguration>(
            context.Configuration.GetSection(BotConfiguration.Configuration));

            services.AddHttpClient("telegram_bot_client")
                    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                    {
                        BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                        TelegramBotClientOptions options = new(botConfig.BotToken);
                        return new TelegramBotClient(options, httpClient);
                    });

            services.AddScoped<UpdateHandler>();
            services.AddScoped<ReceiverService>();
            services.AddHostedService<PollingService>();

            return services;
        }
    }
}
