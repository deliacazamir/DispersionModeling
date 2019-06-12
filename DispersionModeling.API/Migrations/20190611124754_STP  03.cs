using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class STP03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationTypePollutant_Pollutants_PollutantID",
                table: "StationTypePollutant");

            migrationBuilder.DropForeignKey(
                name: "FK_StationTypePollutant_StationTypes_StationTypeID",
                table: "StationTypePollutant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationTypePollutant",
                table: "StationTypePollutant");

            migrationBuilder.RenameTable(
                name: "StationTypePollutant",
                newName: "StationTypePollutants");

            migrationBuilder.RenameIndex(
                name: "IX_StationTypePollutant_StationTypeID",
                table: "StationTypePollutants",
                newName: "IX_StationTypePollutants_StationTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationTypePollutants",
                table: "StationTypePollutants",
                columns: new[] { "PollutantID", "StationTypeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StationTypePollutants_Pollutants_PollutantID",
                table: "StationTypePollutants",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationTypePollutants_StationTypes_StationTypeID",
                table: "StationTypePollutants",
                column: "StationTypeID",
                principalTable: "StationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationTypePollutants_Pollutants_PollutantID",
                table: "StationTypePollutants");

            migrationBuilder.DropForeignKey(
                name: "FK_StationTypePollutants_StationTypes_StationTypeID",
                table: "StationTypePollutants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationTypePollutants",
                table: "StationTypePollutants");

            migrationBuilder.RenameTable(
                name: "StationTypePollutants",
                newName: "StationTypePollutant");

            migrationBuilder.RenameIndex(
                name: "IX_StationTypePollutants_StationTypeID",
                table: "StationTypePollutant",
                newName: "IX_StationTypePollutant_StationTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationTypePollutant",
                table: "StationTypePollutant",
                columns: new[] { "PollutantID", "StationTypeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StationTypePollutant_Pollutants_PollutantID",
                table: "StationTypePollutant",
                column: "PollutantID",
                principalTable: "Pollutants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationTypePollutant_StationTypes_StationTypeID",
                table: "StationTypePollutant",
                column: "StationTypeID",
                principalTable: "StationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
