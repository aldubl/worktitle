using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTitle.Infrastructure.PostgreSql.Migrationspace
{
    /// <inheritdoc />
    public partial class ChangeUserNameChatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "ChatId",
                table: "User",
                type: "bigint",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "ChatId",
                table: "User",
                type: "bigint",
                maxLength: 100,
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
