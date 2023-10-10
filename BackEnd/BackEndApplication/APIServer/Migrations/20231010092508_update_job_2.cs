using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_job_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_JobPosts_JobPostJobId",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "CVApplies");

            migrationBuilder.RenameColumn(
                name: "JobPostJobId",
                table: "CVApplies",
                newName: "JobPostId");

            migrationBuilder.RenameIndex(
                name: "IX_CVApplies_JobPostJobId",
                table: "CVApplies",
                newName: "IX_CVApplies_JobPostId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApplied",
                table: "CVApplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7649), new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7633), new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7649) });

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_JobPosts_JobPostId",
                table: "CVApplies",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_JobPosts_JobPostId",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "DateApplied",
                table: "CVApplies");

            migrationBuilder.RenameColumn(
                name: "JobPostId",
                table: "CVApplies",
                newName: "JobPostJobId");

            migrationBuilder.RenameIndex(
                name: "IX_CVApplies_JobPostId",
                table: "CVApplies",
                newName: "IX_CVApplies_JobPostJobId");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "CVApplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7698), new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7686), new DateTime(2023, 10, 10, 16, 23, 32, 166, DateTimeKind.Local).AddTicks(7699) });

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_JobPosts_JobPostJobId",
                table: "CVApplies",
                column: "JobPostJobId",
                principalTable: "JobPosts",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
