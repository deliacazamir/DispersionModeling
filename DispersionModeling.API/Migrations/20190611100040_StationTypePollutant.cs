using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class StationTypePollutant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StationTypePollutant",
                columns: table => new
                {
                    StationTypeID = table.Column<int>(nullable: false),
                    PollutantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationTypePollutant", x => new { x.PollutantID, x.StationTypeID });
                    table.ForeignKey(
                        name: "FK_StationTypePollutant_Pollutants_PollutantID",
                        column: x => x.PollutantID,
                        principalTable: "Pollutants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationTypePollutant_StationTypes_StationTypeID",
                        column: x => x.StationTypeID,
                        principalTable: "StationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StationTypePollutant_StationTypeID",
                table: "StationTypePollutant",
                column: "StationTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationTypePollutant");
        }
    }
}
