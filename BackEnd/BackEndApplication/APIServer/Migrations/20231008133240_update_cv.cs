using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_cv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "CurriculumVitaes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 8, 20, 32, 40, 273, DateTimeKind.Local).AddTicks(7576), new DateTime(2023, 10, 8, 20, 32, 40, 273, DateTimeKind.Local).AddTicks(7565), new DateTime(2023, 10, 8, 20, 32, 40, 273, DateTimeKind.Local).AddTicks(7576) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "CurriculumVitaes");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "Created_Date", "DOB", "Last_Date" },
                values: new object[] { new DateTime(2023, 10, 6, 15, 32, 15, 523, DateTimeKind.Local).AddTicks(3684), new DateTime(2023, 10, 6, 15, 32, 15, 523, DateTimeKind.Local).AddTicks(3671), new DateTime(2023, 10, 6, 15, 32, 15, 523, DateTimeKind.Local).AddTicks(3685) });
        }
    }
}
