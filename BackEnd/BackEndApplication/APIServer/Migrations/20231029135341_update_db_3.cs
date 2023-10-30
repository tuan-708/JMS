using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "Recuirters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "CurriculumVitaes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackGroundURL",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "Recuirters");

            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "CurriculumVitaes");

            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BackGroundURL",
                table: "Companies");
        }
    }
}
