using Microsoft.EntityFrameworkCore.Migrations;

namespace DispersionModeling.API.Migrations
{
    public partial class UserDispersionModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDispersionModels");
        }
    }
}
