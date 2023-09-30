using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Infrastructure.PostgreSql.Perstistance.Configurations
{
    internal class ScoreHistoryConfiguration : IEntityTypeConfiguration<ScoreHistory>
    {
        public void Configure(EntityTypeBuilder<ScoreHistory> builder)
        {
            builder.HasKey(e => e.Id).HasName("ScoreHistory_pkey");

            builder.ToTable("ScoreHistory");

            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Date).HasColumnType("time with time zone");
        }
    }
}
