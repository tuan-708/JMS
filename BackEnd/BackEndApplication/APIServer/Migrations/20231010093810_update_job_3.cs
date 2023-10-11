using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_job_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Companies_CompanyId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CompanyId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "users");

            migrationBuilder.CreateTable(
                name: "UserFollowings",
                columns: table => new
                {
                    UserFollowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowings", x => x.UserFollowingId);
                    table.ForeignKey(
                        name: "FK_UserFollowings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollowings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 38, 10, 465, DateTimeKind.Local).AddTicks(8853), new DateTime(2023, 10, 10, 16, 38, 10, 465, DateTimeKind.Local).AddTicks(8839), new DateTime(2023, 10, 10, 16, 38, 10, 465, DateTimeKind.Local).AddTicks(8854) });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowings_CompanyId",
                table: "UserFollowings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowings_UserId",
                table: "UserFollowings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowings");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7649), new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7633), new DateTime(2023, 10, 10, 16, 25, 7, 806, DateTimeKind.Local).AddTicks(7649) });

            migrationBuilder.CreateIndex(
                name: "IX_users_CompanyId",
                table: "users",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Companies_CompanyId",
                table: "users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }
    }
}
