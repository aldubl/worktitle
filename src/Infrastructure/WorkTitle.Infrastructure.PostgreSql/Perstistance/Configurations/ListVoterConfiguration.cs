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
    internal class ListVoterConfiguration : IEntityTypeConfiguration<ListVoter>
    {
        public void Configure(EntityTypeBuilder<ListVoter> builder)
        {
            builder.HasNoKey()
                   .ToTable("ListVoter");

            builder.HasOne(d => d.List).WithMany()
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("List");

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User");
        }
    }
}
