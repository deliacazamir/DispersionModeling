using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class addeduserinpollutantsource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PollutionSourceID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StationTypeID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "PollutionSources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PollutionSources_UserID",
                table: "PollutionSources",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PollutionSources_Users_UserID",
                table: "PollutionSources",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollutionSources_Users_UserID",
                table: "PollutionSources");

            migrationBuilder.DropIndex(
                name: "IX_PollutionSources_UserID",
                table: "PollutionSources");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PollutionSources");

            migrationBuilder.AddColumn<int>(
                name: "PollutionSourceID",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StationTypeID",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }
    }
}
