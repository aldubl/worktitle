﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkTitle.Infrastructure.PostgreSql.Perstistance;

#nullable disable

namespace WorkTitle.Infrastructure.PostgreSql.Migrationspace
{
    [DbContext(typeof(WorkTitleContext))]
    partial class WorkTitleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ListId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("ListGroup", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id")
                        .HasName("ListType_pkey");

                    b.ToTable("ListType", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListVoter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ListId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("ListVoter", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.PriceHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnType("time with time zone");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PriceHistory_pkey");

                    b.ToTable("PriceHistory", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<decimal?>("Fullness")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("0");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<bool>("IsMined")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("LastPrice")
                        .HasColumnType("money");

                    b.Property<short?>("LastScore")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ListId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<short?>("Priority")
                        .HasColumnType("smallint");

                    b.Property<string>("Url")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<short?>("Vote")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("Product_pkey");

                    b.HasIndex("ListId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                            Description = "System administrator with full access and control.",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                            Description = "User with standard permissions.",
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("73745220-8b23-445c-83b1-ae3662dce2b2"),
                            Description = "Limited access guest account.",
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ScoreHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnType("time with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<short?>("Score")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("ScoreHistory_pkey");

                    b.ToTable("ScoreHistory", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<long?>("ChatId")
                        .HasMaxLength(100)
                        .HasColumnType("bigint");

                    b.Property<Guid>("DefaultListId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("Users_pkey");

                    b.HasIndex("DefaultListId");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.WishList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsShowFullness")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsShowMined")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<short?>("NeedVotes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("List_pkey");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("List", (string)null);
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListGroup", b =>
                {
                    b.HasOne("WorkTitle.Domain.Entities.WishList", "List")
                        .WithMany()
                        .HasForeignKey("ListId")
                        .HasConstraintName("List");

                    b.HasOne("WorkTitle.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("User");

                    b.Navigation("List");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListVoter", b =>
                {
                    b.HasOne("WorkTitle.Domain.Entities.WishList", "List")
                        .WithMany()
                        .HasForeignKey("ListId")
                        .HasConstraintName("List");

                    b.HasOne("WorkTitle.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("User");

                    b.Navigation("List");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.Product", b =>
                {
                    b.HasOne("WorkTitle.Domain.Entities.WishList", "List")
                        .WithMany("Products")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired()
                        .HasConstraintName("List");

                    b.Navigation("List");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.User", b =>
                {
                    b.HasOne("WorkTitle.Domain.Entities.WishList", "DefaultList")
                        .WithMany("Users")
                        .HasForeignKey("DefaultListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("DefaultListId");

                    b.HasOne("WorkTitle.Domain.Entities.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("DefaultList");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.WishList", b =>
                {
                    b.HasOne("WorkTitle.Domain.Entities.ListType", "Type")
                        .WithMany("Lists")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("Type");

                    b.HasOne("WorkTitle.Domain.Entities.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("User");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.ListType", b =>
                {
                    b.Navigation("Lists");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.User", b =>
                {
                    b.Navigation("Lists");
                });

            modelBuilder.Entity("WorkTitle.Domain.Entities.WishList", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
