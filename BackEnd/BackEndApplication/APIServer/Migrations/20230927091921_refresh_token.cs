using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class refresh_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 9, 27, 16, 19, 21, 54, DateTimeKind.Local).AddTicks(3662), new DateTime(2023, 9, 27, 16, 19, 21, 54, DateTimeKind.Local).AddTicks(3651), new DateTime(2023, 9, 27, 16, 19, 21, 54, DateTimeKind.Local).AddTicks(3663) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3847), new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3828), new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3848) });
        }
    }
}
