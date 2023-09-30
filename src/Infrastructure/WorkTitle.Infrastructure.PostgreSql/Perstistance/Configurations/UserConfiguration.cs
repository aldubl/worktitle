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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("Users_pkey");

            builder.ToTable("User");

            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.ChatId).HasMaxLength(100);
            builder.Property(e => e.Login).HasMaxLength(250);
            builder.Property(e => e.Name).HasMaxLength(1500);
            builder.Property(e => e.PhotoUrl).HasMaxLength(1000);

            builder.HasOne(d => d.DefaultList).WithMany(p => p.Users)
                .HasForeignKey(d => d.DefaultListId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DefaultListId");
        }
    }
}
