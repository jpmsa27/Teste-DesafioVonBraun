using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEndVonBraun.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Comandos");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Comando");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Devices",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Comandos",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Comando",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
