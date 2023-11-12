using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "JobExperiences");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "JobExperiences",
                newName: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "ToYear",
                table: "Educations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromYear",
                table: "Educations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Font",
                table: "CVMatchings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Theme",
                table: "CVMatchings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Font",
                table: "CurriculumVitaes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Theme",
                table: "CurriculumVitaes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromYear",
                table: "Awards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Font",
                table: "CVMatchings");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "CVMatchings");

            migrationBuilder.DropColumn(
                name: "Font",
                table: "CurriculumVitaes");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "CurriculumVitaes");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "JobExperiences",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JobExperiences",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ToYear",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromYear",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromYear",
                table: "Awards",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
