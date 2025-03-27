using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDb1.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");
        }
    }
}
