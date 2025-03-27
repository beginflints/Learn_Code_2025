using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Ray.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoofColor",
                table: "Vehicles",
                newName: "Speed");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Vehicles",
                newName: "RoofColor");
        }
    }
}
