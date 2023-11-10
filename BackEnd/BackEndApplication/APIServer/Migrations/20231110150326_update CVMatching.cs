using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class updateCVMatching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVApplies");

            migrationBuilder.CreateTable(
                name: "CVMatchings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    JobDescriptionId = table.Column<int>(type: "int", nullable: true),
                    CareerGoal = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    DisplayEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Award = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSONMatching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentMatching = table.Column<float>(type: "real", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMatched = table.Column<bool>(type: "bit", nullable: false),
                    IsApplied = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsReject = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVMatchings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVMatchings_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVMatchings_CurriculumVitaes_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitaes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVMatchings_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: "FK_CVMatchings_JobDescriptions_JobDescriptionId",
                        column: x => x.JobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_CVMatchings_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_CandidateId",
                table: "CVMatchings",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_CurriculumVitaeId",
                table: "CVMatchings",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_GenderId",
                table: "CVMatchings",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_JobDescriptionId",
                table: "CVMatchings",
                column: "JobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_LevelId",
                table: "CVMatchings",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVMatchings");

            migrationBuilder.CreateTable(
                name: "CVApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    JobDescriptionId = table.Column<int>(type: "int", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Award = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareerGoal = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApplied = table.Column<bool>(type: "bit", nullable: false),
                    IsAutoMatched = table.Column<bool>(type: "bit", nullable: false),
                    IsReject = table.Column<bool>(type: "bit", nullable: true),
                    JSONMatching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentMatching = table.Column<float>(type: "real", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVApplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVApplies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVApplies_CurriculumVitaes_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitaes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVApplies_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: "FK_CVApplies_JobDescriptions_JobDescriptionId",
                        column: x => x.JobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_CVApplies_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_CandidateId",
                table: "CVApplies",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_CurriculumVitaeId",
                table: "CVApplies",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_GenderId",
                table: "CVApplies",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_JobDescriptionId",
                table: "CVApplies",
                column: "JobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_LevelId",
                table: "CVApplies",
                column: "LevelId");
        }
    }
}
