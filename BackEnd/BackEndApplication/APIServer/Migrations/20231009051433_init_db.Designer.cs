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
    [Migration("20231009051433_init_db")]
    partial class init_db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIServer.Models.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CurriculumVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Award")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinding")
                        .HasColumnType("bit");

                    b.Property<string>("JobExperience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelApply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("CurriculumVitaes");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobPost", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateBenefit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailConnect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExipredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobRequirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelRequired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalaryMax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalaryMin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("JobPosts");
                });

            modelBuilder.Entity("APIServer.Models.Entity.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("createdBy")
                        .HasColumnType("int")
                        .HasColumnName("Created_By");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_Date");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2")
                        .HasColumnName("DOB");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Full_Name");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Active");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Delete");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Date");

                    b.Property<bool>("male")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Male");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Password");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Phone_Number");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("User_Name");

                    b.HasKey("id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 1,
                            createdDate = new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2540),
                            dob = new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2526),
                            email = "admin@JMS.com",
                            fullName = "super admin",
                            isActive = true,
                            isDelete = false,
                            lastUpdate = new DateTime(2023, 10, 9, 12, 14, 33, 65, DateTimeKind.Local).AddTicks(2541),
                            male = true,
                            password = "admin",
                            phoneNumber = "1234567890",
                            role = 0,
                            userName = "admin"
                        });
                });

            modelBuilder.Entity("CurriculumVitaeJobPost", b =>
                {
                    b.Property<int>("CurriculumVitaesId")
                        .HasColumnType("int");

                    b.Property<int>("JobPostsJobId")
                        .HasColumnType("int");

                    b.HasKey("CurriculumVitaesId", "JobPostsJobId");

                    b.HasIndex("JobPostsJobId");

                    b.ToTable("CurriculumVitaeJobPost");
                });

            modelBuilder.Entity("APIServer.Models.Entity.CurriculumVitae", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("APIServer.Models.Entity.User", "User")
                        .WithMany("CurriculumVitaes")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIServer.Models.Entity.JobPost", b =>
                {
                    b.HasOne("APIServer.Models.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("APIServer.Models.Entity.User", "User")
                        .WithMany("JobPosts")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CurriculumVitaeJobPost", b =>
                {
                    b.HasOne("APIServer.Models.Entity.CurriculumVitae", null)
                        .WithMany()
                        .HasForeignKey("CurriculumVitaesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIServer.Models.Entity.JobPost", null)
                        .WithMany()
                        .HasForeignKey("JobPostsJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIServer.Models.Entity.User", b =>
                {
                    b.Navigation("CurriculumVitaes");

                    b.Navigation("JobPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
