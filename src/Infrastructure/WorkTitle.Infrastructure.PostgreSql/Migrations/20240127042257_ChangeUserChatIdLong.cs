using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

#nullable disable

namespace WorkTitle.Infrastructure.PostgreSql.Migrationspace
{
    /// <inheritdoc />
    public partial class ChangeUserChatIdLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500,
                oldNullable: true);                       

            migrationBuilder.Sql(
                @"ALTER TABLE ""User"" ALTER COLUMN ""ChatId"" DROP DEFAULT;"
            );

            migrationBuilder.Sql(
                @"ALTER TABLE ""User"" ALTER COLUMN ""ChatId"" TYPE bigint USING ""ChatId""::bigint;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);
        }
    }
}
