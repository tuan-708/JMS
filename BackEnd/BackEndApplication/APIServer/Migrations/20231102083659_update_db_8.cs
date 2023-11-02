using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaes_PositionTitles_PositionTitleId",
                table: "CurriculumVitaes");

            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_PositionTitles_PositionTitleId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_PositionTitles_PositionTitlesId",
                table: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "PositionTitles");

            migrationBuilder.RenameColumn(
                name: "PositionTitlesId",
                table: "JobDescriptions",
                newName: "LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_PositionTitlesId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_LevelId");

            migrationBuilder.RenameColumn(
                name: "PositionTitleId",
                table: "CVApplies",
                newName: "LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CVApplies_PositionTitleId",
                table: "CVApplies",
                newName: "IX_CVApplies_LevelId");

            migrationBuilder.RenameColumn(
                name: "PositionTitleId",
                table: "CurriculumVitaes",
                newName: "LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CurriculumVitaes_PositionTitleId",
                table: "CurriculumVitaes",
                newName: "IX_CurriculumVitaes_LevelId");

            migrationBuilder.AddColumn<string>(
                name: "PositionTitle",
                table: "JobDescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaes_Levels_LevelId",
                table: "CurriculumVitaes",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_Levels_LevelId",
                table: "CVApplies",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_Levels_LevelId",
                table: "JobDescriptions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaes_Levels_LevelId",
                table: "CurriculumVitaes");

            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_Levels_LevelId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_Levels_LevelId",
                table: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropColumn(
                name: "PositionTitle",
                table: "JobDescriptions");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "JobDescriptions",
                newName: "PositionTitlesId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_LevelId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_PositionTitlesId");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "CVApplies",
                newName: "PositionTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_CVApplies_LevelId",
                table: "CVApplies",
                newName: "IX_CVApplies_PositionTitleId");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "CurriculumVitaes",
                newName: "PositionTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_CurriculumVitaes_LevelId",
                table: "CurriculumVitaes",
                newName: "IX_CurriculumVitaes_PositionTitleId");

            migrationBuilder.CreateTable(
                name: "PositionTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTitles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaes_PositionTitles_PositionTitleId",
                table: "CurriculumVitaes",
                column: "PositionTitleId",
                principalTable: "PositionTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_PositionTitles_PositionTitleId",
                table: "CVApplies",
                column: "PositionTitleId",
                principalTable: "PositionTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_PositionTitles_PositionTitlesId",
                table: "JobDescriptions",
                column: "PositionTitlesId",
                principalTable: "PositionTitles",
                principalColumn: "Id");
        }
    }
}
