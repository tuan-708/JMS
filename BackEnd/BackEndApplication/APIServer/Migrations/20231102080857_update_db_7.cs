using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDescriptionPositionTitle");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Recuirters");

            migrationBuilder.DropColumn(
                name: "GenderRequirement",
                table: "JobDescriptions");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "CurriculumVitaes");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Recuirters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "JobDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionTitlesId",
                table: "JobDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurriculumVitaeId",
                table: "CVApplies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "CVApplies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "CVApplies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "CurriculumVitaes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFindingJob",
                table: "CurriculumVitaes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Title" },
                values: new object[] { 1, "None" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Title" },
                values: new object[] { 2, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Title" },
                values: new object[] { 3, "Female" });

            migrationBuilder.CreateIndex(
                name: "IX_Recuirters_GenderId",
                table: "Recuirters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptions_GenderId",
                table: "JobDescriptions",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptions_PositionTitlesId",
                table: "JobDescriptions",
                column: "PositionTitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_CurriculumVitaeId",
                table: "CVApplies",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_GenderId",
                table: "CVApplies",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVitaes_GenderId",
                table: "CurriculumVitaes",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GenderId",
                table: "Candidates",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaes_Genders_GenderId",
                table: "CurriculumVitaes",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_CurriculumVitaes_CurriculumVitaeId",
                table: "CVApplies",
                column: "CurriculumVitaeId",
                principalTable: "CurriculumVitaes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_Genders_GenderId",
                table: "CVApplies",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_Genders_GenderId",
                table: "JobDescriptions",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_PositionTitles_PositionTitlesId",
                table: "JobDescriptions",
                column: "PositionTitlesId",
                principalTable: "PositionTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recuirters_Genders_GenderId",
                table: "Recuirters",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaes_Genders_GenderId",
                table: "CurriculumVitaes");

            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_CurriculumVitaes_CurriculumVitaeId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_Genders_GenderId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_Genders_GenderId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_PositionTitles_PositionTitlesId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recuirters_Genders_GenderId",
                table: "Recuirters");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Recuirters_GenderId",
                table: "Recuirters");

            migrationBuilder.DropIndex(
                name: "IX_JobDescriptions_GenderId",
                table: "JobDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_JobDescriptions_PositionTitlesId",
                table: "JobDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_CVApplies_CurriculumVitaeId",
                table: "CVApplies");

            migrationBuilder.DropIndex(
                name: "IX_CVApplies_GenderId",
                table: "CVApplies");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumVitaes_GenderId",
                table: "CurriculumVitaes");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_GenderId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Recuirters");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "JobDescriptions");

            migrationBuilder.DropColumn(
                name: "PositionTitlesId",
                table: "JobDescriptions");

            migrationBuilder.DropColumn(
                name: "CurriculumVitaeId",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "CurriculumVitaes");

            migrationBuilder.DropColumn(
                name: "IsFindingJob",
                table: "CurriculumVitaes");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Candidates");

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Recuirters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GenderRequirement",
                table: "JobDescriptions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "CVApplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "CurriculumVitaes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "JobDescriptionPositionTitle",
                columns: table => new
                {
                    JobDescriptionsJobId = table.Column<int>(type: "int", nullable: false),
                    PositionTitlesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptionPositionTitle", x => new { x.JobDescriptionsJobId, x.PositionTitlesId });
                    table.ForeignKey(
                        name: "FK_JobDescriptionPositionTitle_JobDescriptions_JobDescriptionsJobId",
                        column: x => x.JobDescriptionsJobId,
                        principalTable: "JobDescriptions",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobDescriptionPositionTitle_PositionTitles_PositionTitlesId",
                        column: x => x.PositionTitlesId,
                        principalTable: "PositionTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptionPositionTitle_PositionTitlesId",
                table: "JobDescriptionPositionTitle",
                column: "PositionTitlesId");
        }
    }
}
