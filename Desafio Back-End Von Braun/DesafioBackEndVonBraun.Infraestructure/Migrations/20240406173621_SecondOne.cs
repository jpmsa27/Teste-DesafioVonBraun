using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEndVonBraun.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Devices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Devices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
