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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("Product_pkey");

            builder.ToTable("Product");

            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e => e.Fullness)
                .HasDefaultValueSql("0")
                .HasColumnType("money");
            builder.Property(e => e.LastPrice).HasColumnType("money");
            builder.Property(e => e.Name).HasMaxLength(1000);
            builder.Property(e => e.PhotoUrl).HasMaxLength(1000);
            builder.Property(e => e.Url).HasMaxLength(1000);

            builder.HasOne(d => d.List).WithMany(p => p.Products)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("List");
        }
    }
}
