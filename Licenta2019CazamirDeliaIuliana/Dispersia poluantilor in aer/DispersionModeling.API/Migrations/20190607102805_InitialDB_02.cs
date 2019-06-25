using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class InitialDB_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrganic",
                table: "Pollutants");

            migrationBuilder.AddColumn<string>(
                name: "TerrainType",
                table: "PollutionSources",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganicType",
                table: "Pollutants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerrainType",
                table: "PollutionSources");

            migrationBuilder.DropColumn(
                name: "OrganicType",
                table: "Pollutants");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganic",
                table: "Pollutants",
                nullable: false,
                defaultValue: false);
        }
    }
}
