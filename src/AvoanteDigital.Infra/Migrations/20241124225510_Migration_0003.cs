using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvoanteDigital.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Migration_0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.AddColumn<ulong>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                type: "varchar(4000)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
