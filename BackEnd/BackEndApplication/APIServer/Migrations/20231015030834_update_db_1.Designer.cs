﻿// <auto-generated />
using System;
using APIServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIServer.Migrations
{
    [DbContext(typeof(JMSDBContext))]
    [Migration("20231015030834_update_db_1")]
    partial class update_db_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIServer.Models.Entity.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AwardName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<int>("FromYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CertificateProvider")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("credentialURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TotalEmployee")
                        .HasColumnType("int");

                    b.Property<int?>("TotalFollower")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPost")
                        .HasColumnType("int");

                    b.Property<string>("WebURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CurriculumVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("CareerGoal")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayEmail")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("PositionTitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("PositionTitleId");

                    b.ToTable("CurriculumVitaes");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CVApply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Award")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("CareerGoal")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Certificate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<int?>("JobDescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("JobExperience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("PositionTitleId")
                        .HasColumnType("int");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobDescriptionId");

                    b.HasIndex("PositionTitleId");

                    b.ToTable("CVApplies");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<int>("FromYear")
                        .HasColumnType("int");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("StillLearning")
                        .HasColumnType("bit");

                    b.Property<int>("ToYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("APIServer.Models.Entity.EmployeeInCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<int?>("RecuirterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RecuirterId");

                    b.ToTable("EmployeeInCompanies");
                });

            modelBuilder.Entity("APIServer.Models.Entity.EmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Following", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("UserFollowings");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobDescription", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgeRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateBenefit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CertificateRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ExperienceRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenderRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionTitleId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecuirterId")
                        .HasColumnType("int");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("JobId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("PositionTitleId");

                    b.HasIndex("RecuirterId");

                    b.ToTable("JobPosts");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComapanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.HasIndex("EmploymentTypeId");

                    b.ToTable("JobExperiences");
                });

            modelBuilder.Entity("APIServer.Models.Entity.PositionTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PositionTitles");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsStillWorking")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Recuirter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Recuirter");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<string>("SkillDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CandidateCompany", b =>
                {
                    b.Property<int>("CandidatesFollowingId")
                        .HasColumnType("int");

                    b.Property<int>("CompaniesFollowCompanyId")
                        .HasColumnType("int");

                    b.HasKey("CandidatesFollowingId", "CompaniesFollowCompanyId");

                    b.HasIndex("CompaniesFollowCompanyId");

                    b.ToTable("CandidateCompany");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Award", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Awards")
                        .HasForeignKey("CurriculumVitaeId");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Certificate", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Certificates")
                        .HasForeignKey("CurriculumVitaeId");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Company", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CurriculumVitae", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("APIServer.Models.Entity.Category", null)
                        .WithMany("CurriculumVitaes")
                        .HasForeignKey("CategoryId");

                    b.HasOne("APIServer.Models.Entity.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId");

                    b.HasOne("APIServer.Models.Entity.PositionTitle", "PositionTitle")
                        .WithMany("CurriculumVitaes")
                        .HasForeignKey("PositionTitleId");

                    b.Navigation("Candidate");

                    b.Navigation("EmploymentType");

                    b.Navigation("PositionTitle");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CVApply", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("APIServer.Models.Entity.JobDescription", "JobDescription")
                        .WithMany()
                        .HasForeignKey("JobDescriptionId");

                    b.HasOne("APIServer.Models.Entity.PositionTitle", null)
                        .WithMany("CVApplies")
                        .HasForeignKey("PositionTitleId");

                    b.Navigation("Candidate");

                    b.Navigation("JobDescription");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Education", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Educations")
                        .HasForeignKey("CurriculumVitaeId");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("APIServer.Models.Entity.EmployeeInCompany", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Company", "Company")
                        .WithMany("EmployeeInCompanies")
                        .HasForeignKey("CompanyId");

                    b.HasOne("APIServer.Models.Entity.Recuirter", "Recuirter")
                        .WithMany("EmployeeInCompanies")
                        .HasForeignKey("RecuirterId");

                    b.Navigation("Company");

                    b.Navigation("Recuirter");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Following", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("APIServer.Models.Entity.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Candidate");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobDescription", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Category", "Category")
                        .WithMany("JobPosts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("APIServer.Models.Entity.Company", "Company")
                        .WithMany("JobDescriptions")
                        .HasForeignKey("CompanyId");

                    b.HasOne("APIServer.Models.Entity.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId");

                    b.HasOne("APIServer.Models.Entity.PositionTitle", "PositionTitle")
                        .WithMany("JobDescriptions")
                        .HasForeignKey("PositionTitleId");

                    b.HasOne("APIServer.Models.Entity.Recuirter", "Recuirter")
                        .WithMany()
                        .HasForeignKey("RecuirterId");

                    b.Navigation("Category");

                    b.Navigation("Company");

                    b.Navigation("EmploymentType");

                    b.Navigation("PositionTitle");

                    b.Navigation("Recuirter");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobExperience", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("JobExperiences")
                        .HasForeignKey("CurriculumVitaeId");

                    b.HasOne("APIServer.Models.Entity.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId");

                    b.Navigation("CurriculumVitae");

                    b.Navigation("EmploymentType");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Project", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Projects")
                        .HasForeignKey("CurriculumVitaeId");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Recuirter", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Role", "Role")
                        .WithMany("Recuirters")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Skill", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Skills")
                        .HasForeignKey("CurriculumVitaeId");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CandidateCompany", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesFollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIServer.Models.Entity.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesFollowCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIServer.Models.Entity.Category", b =>
                {
                    b.Navigation("CurriculumVitaes");

                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Company", b =>
                {
                    b.Navigation("EmployeeInCompanies");

                    b.Navigation("JobDescriptions");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CurriculumVitae", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Certificates");

                    b.Navigation("Educations");

                    b.Navigation("JobExperiences");

                    b.Navigation("Projects");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("APIServer.Models.Entity.PositionTitle", b =>
                {
                    b.Navigation("CVApplies");

                    b.Navigation("CurriculumVitaes");

                    b.Navigation("JobDescriptions");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Recuirter", b =>
                {
                    b.Navigation("EmployeeInCompanies");
                });

            modelBuilder.Entity("APIServer.Models.Entity.Role", b =>
                {
                    b.Navigation("Recuirters");
                });
#pragma warning restore 612, 618
        }
    }
}
