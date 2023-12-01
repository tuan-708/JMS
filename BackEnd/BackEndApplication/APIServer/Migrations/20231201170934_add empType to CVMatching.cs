using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class addempTypetoCVMatching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeId",
                table: "CVMatchings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CVMatchings_EmploymentTypeId",
                table: "CVMatchings",
                column: "EmploymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVMatchings_EmploymentTypes_EmploymentTypeId",
                table: "CVMatchings",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVMatchings_EmploymentTypes_EmploymentTypeId",
                table: "CVMatchings");

            migrationBuilder.DropIndex(
                name: "IX_CVMatchings_EmploymentTypeId",
                table: "CVMatchings");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                table: "CVMatchings");
        }
    }
}
