using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class AddedGps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDispersionModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPSLocations",
                table: "GPSLocations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GPSLocations");

            migrationBuilder.RenameColumn(
                name: "Altitude",
                table: "GPSLocations",
                newName: "Concentration");

            migrationBuilder.AddColumn<int>(
                name: "PollutantID",
                table: "GPSLocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPSLocations",
                table: "GPSLocations",
                columns: new[] { "Latitude", "Longitude", "PollutantID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GPSLocations",
                table: "GPSLocations");

            migrationBuilder.DropColumn(
                name: "PollutantID",
                table: "GPSLocations");

            migrationBuilder.RenameColumn(
                name: "Concentration",
                table: "GPSLocations",
                newName: "Altitude");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GPSLocations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPSLocations",
                table: "GPSLocations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserDispersionModels",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    DispersionModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDispersionModels", x => new { x.UserID, x.DispersionModelID });
                    table.ForeignKey(
                        name: "FK_UserDispersionModels_DispersionModels_DispersionModelID",
                        column: x => x.DispersionModelID,
                        principalTable: "DispersionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDispersionModels_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDispersionModels_DispersionModelID",
                table: "UserDispersionModels",
                column: "DispersionModelID");
        }
    }
}
