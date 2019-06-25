using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispersionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmokeExitSpeed = table.Column<double>(nullable: false),
                    ExitTemperature = table.Column<double>(nullable: false),
                    EmissionOfPollutantsConcentration = table.Column<double>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    TerrainType = table.Column<string>(nullable: true),
                    CloudCoverage = table.Column<double>(nullable: false),
                    AtmosphericConditions = table.Column<double>(nullable: false),
                    AirTemperature = table.Column<double>(nullable: false),
                    SolarRadiations = table.Column<double>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindSpeedAtTenMetters = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispersionModels", x => x.Id);
                });

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
                name: "Pollutants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ChemicalFormula = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    IsCarcinogenic = table.Column<bool>(nullable: false),
                    IsOrganic = table.Column<bool>(nullable: false),
                    SedimentationSpeed = table.Column<double>(nullable: false),
                    AgregationState = table.Column<string>(nullable: true),
                    LegislativeValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollutants", x => x.Id);
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
                    MaxDistance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollutionSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationTypes", x => x.Id);
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
                name: "Pollutants");

            migrationBuilder.DropTable(
                name: "PollutionSources");

            migrationBuilder.DropTable(
                name: "StationTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
