using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LevelRequired",
                table: "JobPosts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2535), new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2523), new DateTime(2023, 10, 9, 12, 30, 55, 274, DateTimeKind.Local).AddTicks(2536) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LevelRequired",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4015), new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4000), new DateTime(2023, 10, 9, 12, 15, 43, 336, DateTimeKind.Local).AddTicks(4016) });
        }
    }
}
