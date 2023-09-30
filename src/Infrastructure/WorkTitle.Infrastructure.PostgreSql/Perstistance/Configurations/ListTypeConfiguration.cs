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
    internal class ListTypeConfiguration : IEntityTypeConfiguration<ListType>
    {
        public void Configure(EntityTypeBuilder<ListType> builder)
        {
            builder.HasKey(e => e.Id).HasName("ListType_pkey");

            builder.ToTable("ListType");

            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Description).HasMaxLength(300);
        }
    }
}
