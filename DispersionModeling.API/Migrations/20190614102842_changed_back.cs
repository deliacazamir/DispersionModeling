using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class changed_back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserDispersionModels_DispersionModelID",
                table: "UserDispersionModels",
                column: "DispersionModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDispersionModels_DispersionModels_DispersionModelID",
                table: "UserDispersionModels",
                column: "DispersionModelID",
                principalTable: "DispersionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDispersionModels_Users_UserID",
                table: "UserDispersionModels",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDispersionModels_DispersionModels_DispersionModelID",
                table: "UserDispersionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDispersionModels_Users_UserID",
                table: "UserDispersionModels");

            migrationBuilder.DropIndex(
                name: "IX_UserDispersionModels_DispersionModelID",
                table: "UserDispersionModels");
        }
    }
}
