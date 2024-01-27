using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using WorkTitle.Telegramm;
using WorkTitle.Telegramm.Configuration;
using WorkTitle.Telegramm.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddServices(context);
    })
    .Build();

await host.RunAsync();