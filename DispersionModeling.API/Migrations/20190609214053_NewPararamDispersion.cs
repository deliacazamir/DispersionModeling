using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class NewPararamDispersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDistance",
                table: "PollutionSources");

            migrationBuilder.DropColumn(
                name: "TerrainType",
                table: "DispersionModels");

            migrationBuilder.AddColumn<double>(
                name: "MaxDistance",
                table: "DispersionModels",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDistance",
                table: "DispersionModels");

            migrationBuilder.AddColumn<double>(
                name: "MaxDistance",
                table: "PollutionSources",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TerrainType",
                table: "DispersionModels",
                nullable: true);
        }
    }
}
