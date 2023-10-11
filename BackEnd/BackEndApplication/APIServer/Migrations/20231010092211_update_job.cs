using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumVitaeJobPost");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(253), new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(228), new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(254) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumVitaeJobPost",
                columns: table => new
                {
                    CurriculumVitaesId = table.Column<int>(type: "int", nullable: false),
                    JobPostsJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVitaeJobPost", x => new { x.CurriculumVitaesId, x.JobPostsJobId });
                    table.ForeignKey(
                        name: "FK_CurriculumVitaeJobPost_CurriculumVitaes_CurriculumVitaesId",
                        column: x => x.CurriculumVitaesId,
                        principalTable: "CurriculumVitaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumVitaeJobPost_JobPosts_JobPostsJobId",
                        column: x => x.JobPostsJobId,
                        principalTable: "JobPosts",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5942), new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5929), new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVitaeJobPost_JobPostsJobId",
                table: "CurriculumVitaeJobPost",
                column: "JobPostsJobId");
        }
    }
}
