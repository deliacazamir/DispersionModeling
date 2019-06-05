using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class NoRelTables02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispersionModels_PollutionSources_PollutionSourceId",
                table: "DispersionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PollutantLists_PollutionSources_PollutionSourceId",
                table: "PollutantLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PollutionSources_StationTypes_StationTypeId",
                table: "PollutionSources");

            migrationBuilder.DropIndex(
                name: "IX_PollutionSources_StationTypeId",
                table: "PollutionSources");

            migrationBuilder.DropIndex(
                name: "IX_PollutantLists_PollutionSourceId",
                table: "PollutantLists");

            migrationBuilder.DropIndex(
                name: "IX_DispersionModels_PollutionSourceId",
                table: "DispersionModels");

            migrationBuilder.DropColumn(
                name: "StationTypeId",
                table: "PollutionSources");

            migrationBuilder.DropColumn(
                name: "PollutionSourceId",
                table: "PollutantLists");

            migrationBuilder.DropColumn(
                name: "PollutionSourceId",
                table: "DispersionModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationTypeId",
                table: "PollutionSources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PollutionSourceId",
                table: "PollutantLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PollutionSourceId",
                table: "DispersionModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PollutionSources_StationTypeId",
                table: "PollutionSources",
                column: "StationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PollutantLists_PollutionSourceId",
                table: "PollutantLists",
                column: "PollutionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DispersionModels_PollutionSourceId",
                table: "DispersionModels",
                column: "PollutionSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispersionModels_PollutionSources_PollutionSourceId",
                table: "DispersionModels",
                column: "PollutionSourceId",
                principalTable: "PollutionSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollutantLists_PollutionSources_PollutionSourceId",
                table: "PollutantLists",
                column: "PollutionSourceId",
                principalTable: "PollutionSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollutionSources_StationTypes_StationTypeId",
                table: "PollutionSources",
                column: "StationTypeId",
                principalTable: "StationTypes",
                principalColumn: "StationTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
