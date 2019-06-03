using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SourceName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPSLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationTypes",
                columns: table => new
                {
                    StationTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationTypes", x => x.StationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollutionSources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false),
                    ChimneyHeight = table.Column<double>(nullable: false),
                    ChimneyDiameter = table.Column<double>(nullable: false),
                    MaxDistance = table.Column<double>(nullable: false),
                    StationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollutionSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollutionSources_StationTypes_StationTypeId",
                        column: x => x.StationTypeId,
                        principalTable: "StationTypes",
                        principalColumn: "StationTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DispersionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmokeExitSpeed = table.Column<int>(nullable: false),
                    ExitTemperature = table.Column<double>(nullable: false),
                    EmissionOfPollutantsConcentration = table.Column<double>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    TerrainType = table.Column<string>(nullable: true),
                    CloudCoverage = table.Column<int>(nullable: false),
                    AtmosphericConditions = table.Column<int>(nullable: false),
                    AirTemperature = table.Column<int>(nullable: false),
                    SolarRadiations = table.Column<int>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindSpeedAtTenMetters = table.Column<int>(nullable: false),
                    PollutionSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispersionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispersionModels_PollutionSources_PollutionSourceId",
                        column: x => x.PollutionSourceId,
                        principalTable: "PollutionSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollutantLists",
                columns: table => new
                {
                    PollutantListID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ChemicalFormula = table.Column<string>(nullable: true),
                    Measure = table.Column<string>(nullable: true),
                    IsCarcinogenic = table.Column<bool>(nullable: false),
                    IsOrganic = table.Column<bool>(nullable: false),
                    SedimentationSpeed = table.Column<int>(nullable: false),
                    IsGasOrSolid = table.Column<bool>(nullable: false),
                    LegislativeValue = table.Column<int>(nullable: false),
                    PollutionSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollutantLists", x => x.PollutantListID);
                    table.ForeignKey(
                        name: "FK_PollutantLists_PollutionSources_PollutionSourceId",
                        column: x => x.PollutionSourceId,
                        principalTable: "PollutionSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DispersionModels_PollutionSourceId",
                table: "DispersionModels",
                column: "PollutionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PollutantLists_PollutionSourceId",
                table: "PollutantLists",
                column: "PollutionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PollutionSources_StationTypeId",
                table: "PollutionSources",
                column: "StationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispersionModels");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "GPSLocations");

            migrationBuilder.DropTable(
                name: "PollutantLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PollutionSources");

            migrationBuilder.DropTable(
                name: "StationTypes");
        }
    }
}
