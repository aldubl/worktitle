using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Interfaces;
using WorkTitle.Infrastructure.PostgreSql.Perstistance;

namespace WorkTitle.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var conStrBuilder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("WorkTitleContext"))
            {                
                Password = configuration["PostgresPassword"]
            };
            var workTitleContext = conStrBuilder.ConnectionString;
            services.AddDbContext<WorkTitleContext>(options => options.UseNpgsql(workTitleContext
                , x => x.MigrationsAssembly("WorkTitle.Infrastructure.PostgreSql")));

            services.AddScoped<IApplicationContext>(provider => provider.GetRequiredService<WorkTitleContext>());

            return services;
        }

        public static async void InitializeInfrastructureServices(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<WorkTitleContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
