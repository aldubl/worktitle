using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;

namespace WebApiJwtAuthentication.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var portString = configuration["PostgresPort"];
            portString = string.IsNullOrEmpty(portString) ? "5432" : portString;
            int port = int.Parse(portString);

            var conStrBuilder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("ApplicationDbContext"))
            {
                Password = configuration["PostgresPassword"],
                Host = configuration["PostgresHost"],
                Port = port,
                Username = configuration["PostgresUsername"],
                Database = configuration["PostgresDatabase"]
            };
            var applicationContext = conStrBuilder.ConnectionString;
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(applicationContext
                , x => x.MigrationsAssembly("WebApiJwtAuthentication")));

            services.AddScoped<IdentityDbContext>(provider => provider.GetRequiredService<IdentityDbContext>());

            return services;
        }

        public static async void InitializeInfrastructureServices(this IServiceProvider provider)
        {
            //using var scope = provider.CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            //await dbContext.Database.MigrateAsync();
        }
    }
}
