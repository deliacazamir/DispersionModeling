using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class PollutantListModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCarcinogenic",
                table: "PollutantLists");

            migrationBuilder.DropColumn(
                name: "IsGasOrSolid",
                table: "PollutantLists");

            migrationBuilder.DropColumn(
                name: "IsOrganic",
                table: "PollutantLists");

            migrationBuilder.DropColumn(
                name: "LegislativeValue",
                table: "PollutantLists");

            migrationBuilder.DropColumn(
                name: "SedimentationSpeed",
                table: "PollutantLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCarcinogenic",
                table: "PollutantLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGasOrSolid",
                table: "PollutantLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganic",
                table: "PollutantLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LegislativeValue",
                table: "PollutantLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SedimentationSpeed",
                table: "PollutantLists",
                nullable: false,
                defaultValue: 0);
        }
    }
}
