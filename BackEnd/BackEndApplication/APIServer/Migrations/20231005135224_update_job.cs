using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 5, 20, 52, 23, 673, DateTimeKind.Local).AddTicks(1691), new DateTime(2023, 10, 5, 20, 52, 23, 673, DateTimeKind.Local).AddTicks(1676), new DateTime(2023, 10, 5, 20, 52, 23, 673, DateTimeKind.Local).AddTicks(1692) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 5, 17, 11, 59, 556, DateTimeKind.Local).AddTicks(6527), new DateTime(2023, 10, 5, 17, 11, 59, 556, DateTimeKind.Local).AddTicks(6515), new DateTime(2023, 10, 5, 17, 11, 59, 556, DateTimeKind.Local).AddTicks(6528) });
        }
    }
}
