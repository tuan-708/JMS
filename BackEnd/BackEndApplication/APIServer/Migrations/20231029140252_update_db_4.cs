using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFollower",
                table: "Companies",
                newName: "RecuirterId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies",
                column: "RecuirterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Recuirters_RecuirterId",
                table: "Companies",
                column: "RecuirterId",
                principalTable: "Recuirters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Recuirters_RecuirterId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "RecuirterId",
                table: "Companies",
                newName: "TotalFollower");
        }
    }
}
