using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkTitle.Infrastructure.PostgreSql.Migrationspace
{
    /// <inheritdoc />
    public partial class UpdateTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("73745220-8b23-445c-83b1-ae3662dce2b2"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "ChatId",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultListId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "User",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "User",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Users_pkey",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ListType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ListType_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "time with time zone", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PriceHistory_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "time with time zone", nullable: true),
                    Score = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ScoreHistory_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsGroup = table.Column<bool>(type: "boolean", nullable: false),
                    NeedVotes = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    IsShowMined = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    IsShowFullness = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("List_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Type",
                        column: x => x.TypeId,
                        principalTable: "ListType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ListGroup",
                columns: table => new
                {
                    ListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "List",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListVoter",
                columns: table => new
                {
                    ListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "List",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LastPrice = table.Column<decimal>(type: "money", nullable: true),
                    LastScore = table.Column<short>(type: "smallint", nullable: true),
                    Priority = table.Column<short>(type: "smallint", nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Vote = table.Column<short>(type: "smallint", nullable: true),
                    IsMined = table.Column<bool>(type: "boolean", nullable: false),
                    Fullness = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    ListId = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Product_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "List",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DefaultListId",
                table: "User",
                column: "DefaultListId");

            migrationBuilder.CreateIndex(
                name: "IX_List_TypeId",
                table: "List",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_List_UserId",
                table: "List",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListGroup_ListId",
                table: "ListGroup",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListGroup_UserId",
                table: "ListGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListVoter_ListId",
                table: "ListVoter",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListVoter_UserId",
                table: "ListVoter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ListId",
                table: "Product",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "DefaultListId",
                table: "User",
                column: "DefaultListId",
                principalTable: "List",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "DefaultListId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ListGroup");

            migrationBuilder.DropTable(
                name: "ListVoter");

            migrationBuilder.DropTable(
                name: "PriceHistory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ScoreHistory");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "ListType");

            migrationBuilder.DropPrimaryKey(
                name: "Users_pkey",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DefaultListId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DefaultListId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"), "System administrator with full access and control.", "Administrator" },
                    { new Guid("73745220-8b23-445c-83b1-ae3662dce2b2"), "Limited access guest account.", "Guest" },
                    { new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"), "User with standard permissions.", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
