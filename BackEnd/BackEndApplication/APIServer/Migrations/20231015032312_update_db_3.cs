using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServer.Migrations
{
    public partial class update_db_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_JobPosts_JobDescriptionId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInCompanies_Recuirter_RecuirterId",
                table: "EmployeeInCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Categories_CategoryId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_EmploymentTypes_EmploymentTypeId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_PositionTitles_PositionTitleId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Recuirter_RecuirterId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Recuirter_Roles_RoleId",
                table: "Recuirter");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_Candidates_CandidateId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_Companies_CompanyId",
                table: "UserFollowings");

            migrationBuilder.DropTable(
                name: "CandidateCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recuirter",
                table: "Recuirter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_PositionTitleId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PositionTitleId",
                table: "JobPosts");

            migrationBuilder.RenameTable(
                name: "UserFollowings",
                newName: "Followings");

            migrationBuilder.RenameTable(
                name: "Recuirter",
                newName: "Recuirters");

            migrationBuilder.RenameTable(
                name: "JobPosts",
                newName: "JobDescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_CompanyId",
                table: "Followings",
                newName: "IX_Followings_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_CandidateId",
                table: "Followings",
                newName: "IX_Followings_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Recuirter_RoleId",
                table: "Recuirters",
                newName: "IX_Recuirters_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_RecuirterId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_RecuirterId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_EmploymentTypeId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_EmploymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_CategoryId",
                table: "JobDescriptions",
                newName: "IX_JobDescriptions_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recuirters",
                table: "Recuirters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobDescriptions",
                table: "JobDescriptions",
                column: "JobId");

            migrationBuilder.CreateTable(
                name: "JobDescriptionPositionTitle",
                columns: table => new
                {
                    JobDescriptionsJobId = table.Column<int>(type: "int", nullable: false),
                    PositionTitlesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptionPositionTitle", x => new { x.JobDescriptionsJobId, x.PositionTitlesId });
                    table.ForeignKey(
                        name: "FK_JobDescriptionPositionTitle_JobDescriptions_JobDescriptionsJobId",
                        column: x => x.JobDescriptionsJobId,
                        principalTable: "JobDescriptions",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobDescriptionPositionTitle_PositionTitles_PositionTitlesId",
                        column: x => x.PositionTitlesId,
                        principalTable: "PositionTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptionPositionTitle_PositionTitlesId",
                table: "JobDescriptionPositionTitle",
                column: "PositionTitlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_JobDescriptions_JobDescriptionId",
                table: "CVApplies",
                column: "JobDescriptionId",
                principalTable: "JobDescriptions",
                principalColumn: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInCompanies_Recuirters_RecuirterId",
                table: "EmployeeInCompanies",
                column: "RecuirterId",
                principalTable: "Recuirters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Candidates_CandidateId",
                table: "Followings",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Companies_CompanyId",
                table: "Followings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_Categories_CategoryId",
                table: "JobDescriptions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_Companies_CompanyId",
                table: "JobDescriptions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_EmploymentTypes_EmploymentTypeId",
                table: "JobDescriptions",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescriptions_Recuirters_RecuirterId",
                table: "JobDescriptions",
                column: "RecuirterId",
                principalTable: "Recuirters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recuirters_Roles_RoleId",
                table: "Recuirters",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVApplies_JobDescriptions_JobDescriptionId",
                table: "CVApplies");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInCompanies_Recuirters_RecuirterId",
                table: "EmployeeInCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Candidates_CandidateId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Companies_CompanyId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_Categories_CategoryId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_Companies_CompanyId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_EmploymentTypes_EmploymentTypeId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDescriptions_Recuirters_RecuirterId",
                table: "JobDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recuirters_Roles_RoleId",
                table: "Recuirters");

            migrationBuilder.DropTable(
                name: "JobDescriptionPositionTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recuirters",
                table: "Recuirters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobDescriptions",
                table: "JobDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.RenameTable(
                name: "Recuirters",
                newName: "Recuirter");

            migrationBuilder.RenameTable(
                name: "JobDescriptions",
                newName: "JobPosts");

            migrationBuilder.RenameTable(
                name: "Followings",
                newName: "UserFollowings");

            migrationBuilder.RenameIndex(
                name: "IX_Recuirters_RoleId",
                table: "Recuirter",
                newName: "IX_Recuirter_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_RecuirterId",
                table: "JobPosts",
                newName: "IX_JobPosts_RecuirterId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_EmploymentTypeId",
                table: "JobPosts",
                newName: "IX_JobPosts_EmploymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_CompanyId",
                table: "JobPosts",
                newName: "IX_JobPosts_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_JobDescriptions_CategoryId",
                table: "JobPosts",
                newName: "IX_JobPosts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_CompanyId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_CandidateId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_CandidateId");

            migrationBuilder.AddColumn<int>(
                name: "PositionTitleId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recuirter",
                table: "Recuirter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CandidateCompany",
                columns: table => new
                {
                    CandidatesFollowingId = table.Column<int>(type: "int", nullable: false),
                    CompaniesFollowCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompany", x => new { x.CandidatesFollowingId, x.CompaniesFollowCompanyId });
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Candidates_CandidatesFollowingId",
                        column: x => x.CandidatesFollowingId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Companies_CompaniesFollowCompanyId",
                        column: x => x.CompaniesFollowCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PositionTitleId",
                table: "JobPosts",
                column: "PositionTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CompaniesFollowCompanyId",
                table: "CandidateCompany",
                column: "CompaniesFollowCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVApplies_JobPosts_JobDescriptionId",
                table: "CVApplies",
                column: "JobDescriptionId",
                principalTable: "JobPosts",
                principalColumn: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInCompanies_Recuirter_RecuirterId",
                table: "EmployeeInCompanies",
                column: "RecuirterId",
                principalTable: "Recuirter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Categories_CategoryId",
                table: "JobPosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_EmploymentTypes_EmploymentTypeId",
                table: "JobPosts",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_PositionTitles_PositionTitleId",
                table: "JobPosts",
                column: "PositionTitleId",
                principalTable: "PositionTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Recuirter_RecuirterId",
                table: "JobPosts",
                column: "RecuirterId",
                principalTable: "Recuirter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recuirter_Roles_RoleId",
                table: "Recuirter",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_Candidates_CandidateId",
                table: "UserFollowings",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_Companies_CompanyId",
                table: "UserFollowings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }
    }
}
