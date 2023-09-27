using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "user_id", "Created_By", "Created_Date", "Description", "DOB", "Email", "Full_Name", "Is_Active", "Is_Delete", "Last_Date", "Is_Male", "Password", "Phone_Number", "role", "User_Name" },
                values: new object[] { 1, null, new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3847), null, new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3828), "admin@JMS.com", "super admin", true, false, new DateTime(2023, 9, 27, 14, 58, 14, 540, DateTimeKind.Local).AddTicks(3848), true, "admin", "1234567890", 0, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
