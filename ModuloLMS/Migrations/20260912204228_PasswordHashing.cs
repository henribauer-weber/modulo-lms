using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloLMS.Migrations
{
    /// <inheritdoc />
    public partial class PasswordHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
