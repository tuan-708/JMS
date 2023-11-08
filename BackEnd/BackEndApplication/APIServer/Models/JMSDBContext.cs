﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APIServer.Models
{
    public class JMSDBContext : DbContext
    {
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public virtual DbSet<CVApply> CVApplies { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<EmployeeInCompany> EmployeeInCompanies { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<JobDescription> JobDescriptions { get; set; }
        public virtual DbSet<JobExperience> JobExperiences { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Recuirter> Recuirters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }

        public JMSDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var conStr = config.GetConnectionString("JobConstr");
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(conStr);
                }
            }
        }

        public JMSDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Recuirter>().HasData(new Recuirter
            //{
            //    id = 1,
            //    fullName = "super admin",
            //    UserName = "admin",
            //    Password = "admin",
            //    Email = "admin@JMS.com",
            //    IsMale = true,
            //    PhoneNumber = "1234567890",
            //    DOB = DateTime.Now,
            //    CreatedDate = DateTime.Now,
            //    LastUpdate = DateTime.Now,
            //    isActive = true,
            //    isDelete = false,
            //    Description = null,
            //});
            modelBuilder.Entity<Gender>().HasData(DataStatic.allGender());
        }
    }
}
