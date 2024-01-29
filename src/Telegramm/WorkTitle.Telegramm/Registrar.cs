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
using WorkTitle.Telegramm.API;
using WorkTitle.Telegramm.API.Interfaces;
using Microsoft.Extensions.Logging;

namespace WorkTitle.Telegramm
{
    internal static class Registrar
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, HostBuilderContext context)
        {
            var conf = context.Configuration;

            services.Configure<BotConfiguration>(
            conf.GetSection(BotConfiguration.Configuration));

            services.AddHttpClient("telegram_bot_client")
                    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                    {
                        BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                        TelegramBotClientOptions options = new(botConfig.BotToken);
                        return new TelegramBotClient(options, httpClient);
                    });

            services.AddScoped<IWorkTitleAuthApi, WorkTitleAuthApi>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<WorkTitleAuthApi>>();

                var url = conf.GetValue<string>("API:AUTH_URL");

                var email = conf.GetValue<string>("API:email");

                var password = conf.GetValue<string>("API:password");

                return new WorkTitleAuthApi(logger, url!, email!, password!);
            }
                );

            services.AddScoped<IWorkTitleApi, WorkTitleApi>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<WorkTitleApi>>();

                var url = conf.GetValue<string>("API:URL");

                var authApi = provider.GetRequiredService<IWorkTitleAuthApi>();

                return new WorkTitleApi(logger, url!, authApi);
            });

            services.AddScoped<UpdateHandler>();
            services.AddScoped<ReceiverService>();

            services.AddHostedService<PollingService>();

            return services;
        }
    }
}
