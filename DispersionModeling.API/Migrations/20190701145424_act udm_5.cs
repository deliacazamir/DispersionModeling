using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class actudm_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HitmapName",
                table: "DispersionModels");

            migrationBuilder.AddColumn<bool>(
                name: "HasMap",
                table: "DispersionModels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasMap",
                table: "DispersionModels");

            migrationBuilder.AddColumn<string>(
                name: "HitmapName",
                table: "DispersionModels",
                nullable: true);
        }
    }
}
