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

    public partial class WorkTitleContext : DbContext, IApplicationContext
    {
        public WorkTitleContext()
        {
        }

        public WorkTitleContext(DbContextOptions<WorkTitleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<List> Lists { get; set; }

        public virtual DbSet<ListGroup> ListGroups { get; set; }

        public virtual DbSet<ListType> ListTypes { get; set; }

        public virtual DbSet<ListVoter> ListVoters { get; set; }

        public virtual DbSet<PriceHistory> PriceHistories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<ScoreHistory> ScoreHistories { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("List_pkey");

                entity.ToTable("List");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.IsShowMined)
                    .IsRequired()
                    .HasDefaultValueSql("true");
                entity.Property(e => e.Name).HasMaxLength(300);
                entity.Property(e => e.NeedVotes).HasDefaultValueSql("0");

                entity.HasOne(d => d.Type).WithMany(p => p.Lists)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Type");

                entity.HasOne(d => d.User).WithMany(p => p.Lists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("User");
            });

            modelBuilder.Entity<ListGroup>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ListGroup");

                entity.HasOne(d => d.List).WithMany()
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("List");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User");
            });

            modelBuilder.Entity<ListType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ListType_pkey");

                entity.ToTable("ListType");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Description).HasMaxLength(300);
            });

            modelBuilder.Entity<ListVoter>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ListVoter");

                entity.HasOne(d => d.List).WithMany()
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("List");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User");
            });

            modelBuilder.Entity<PriceHistory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PriceHistory_pkey");

                entity.ToTable("PriceHistory");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Date).HasColumnType("time with time zone");
                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Product_pkey");

                entity.ToTable("Product");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Fullness)
                    .HasDefaultValueSql("0")
                    .HasColumnType("money");
                entity.Property(e => e.LastPrice).HasColumnType("money");
                entity.Property(e => e.Name).HasMaxLength(1000);
                entity.Property(e => e.PhotoUrl).HasMaxLength(1000);
                entity.Property(e => e.Url).HasMaxLength(1000);

                entity.HasOne(d => d.List).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("List");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ScoreHistory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ScoreHistory_pkey");

                entity.ToTable("ScoreHistory");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Date).HasColumnType("time with time zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Users_pkey");

                entity.ToTable("User");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.ChatId).HasMaxLength(100);
                entity.Property(e => e.Login).HasMaxLength(250);
                entity.Property(e => e.Name).HasMaxLength(1500);
                entity.Property(e => e.PhotoUrl).HasMaxLength(1000);

                entity.HasOne(d => d.DefaultList).WithMany(p => p.Users)
                    .HasForeignKey(d => d.DefaultListId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DefaultListId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}