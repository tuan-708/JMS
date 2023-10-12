using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class add_company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPost = table.Column<int>(type: "int", nullable: true),
                    TotalEmployee = table.Column<int>(type: "int", nullable: true),
                    TotalFollower = table.Column<int>(type: "int", nullable: true),
                    WebURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5942), new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5929), new DateTime(2023, 10, 10, 16, 15, 7, 127, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.CreateIndex(
                name: "IX_users_CompanyId",
                table: "users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Companies_CompanyId",
                table: "users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Companies_CompanyId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_users_CompanyId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobPosts");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2535), new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2523), new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2536) });
        }
    }
}
