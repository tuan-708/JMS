using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class init_db_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaes_User_UserId",
                table: "CurriculumVitaes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_User_UserId",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4015), new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4000), new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaes_users_UserId",
                table: "CurriculumVitaes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_users_UserId",
                table: "JobPosts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaes_users_UserId",
                table: "CurriculumVitaes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_users_UserId",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "user_id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2540), new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2526), new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaes_User_UserId",
                table: "CurriculumVitaes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_User_UserId",
                table: "JobPosts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "user_id");
        }
    }
}
