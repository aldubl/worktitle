using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Interfaces;
using WorkTitle.Domain.Entities;
using WorkTitle.Infrastructure.Perstistance;

namespace WorkTitle.Infrastructure.PostgreSql.Perstistance
{
    public sealed class WorkTitleContext : DbContext, IApplicationContext
    {
        public WorkTitleContext(DbContextOptions<WorkTitleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(SeedData.Roles);
        }
    }
}
