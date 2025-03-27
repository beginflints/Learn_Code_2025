using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Ray.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoofColor",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoofColor",
                table: "Vehicles");
        }
    }
}
