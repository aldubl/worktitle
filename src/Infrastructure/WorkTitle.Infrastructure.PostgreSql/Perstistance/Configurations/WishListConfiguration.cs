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
    internal class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(e => e.Id).HasName("List_pkey");

            builder.ToTable("List");

            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.IsShowMined)
                .IsRequired()
                .HasDefaultValueSql("true");
            builder.Property(e => e.Name).HasMaxLength(300);
            builder.Property(e => e.NeedVotes).HasDefaultValueSql("0");

            builder.HasOne(d => d.Type).WithMany(p => p.Lists)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("Type");

            builder.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User");
        }
    }
}
