using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Fon.Migrations
{
    /// <inheritdoc />
    public partial class Edit_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Vehicles",
                newName: "ReleasedDate");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speed",
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

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "ReleasedDate",
                table: "Vehicles",
                newName: "ReleaseDate");
        }
    }
}
