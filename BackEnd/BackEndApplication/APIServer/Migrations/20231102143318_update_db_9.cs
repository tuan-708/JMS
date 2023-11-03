using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "CVApplies",
                newName: "IsReject");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CVApplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "CVApplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAutoMatched",
                table: "CVApplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "CVApplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "IsAutoMatched",
                table: "CVApplies");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "CVApplies");

            migrationBuilder.RenameColumn(
                name: "IsReject",
                table: "CVApplies",
                newName: "IsAccepted");
        }
    }
}
