using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Recuirters");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Recuirters");

            migrationBuilder.DropColumn(
                name: "TotalEmployee",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "TotalPost",
                table: "Companies",
                newName: "YearOfEstablishment");

            migrationBuilder.AddColumn<string>(
                name: "Tax",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "YearOfEstablishment",
                table: "Companies",
                newName: "TotalPost");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Recuirters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Recuirters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalEmployee",
                table: "Companies",
                type: "int",
                nullable: true);
        }
    }
}
