using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies",
                column: "RecuirterId",
                unique: true,
                filter: "[RecuirterId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RecuirterId",
                table: "Companies",
                column: "RecuirterId");
        }
    }
}
