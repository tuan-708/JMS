using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_job_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobPostJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVApplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVApplies_CurriculumVitaes_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVApplies_JobPosts_JobPostJobId",
                        column: x => x.JobPostJobId,
                        principalTable: "JobPosts",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7698), new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7686), new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7699) });

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_CurriculumVitaeId",
                table: "CVApplies",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_CVApplies_JobPostJobId",
                table: "CVApplies",
                column: "JobPostJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVApplies");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(253), new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(228), new DateTime(2023, 10, 10, 16, 22, 11, 83, DateTimeKind.Local).AddTicks(254) });
        }
    }
}
