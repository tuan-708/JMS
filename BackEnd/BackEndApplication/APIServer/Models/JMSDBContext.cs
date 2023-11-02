using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Models
{
    public class JMSDBContext : DbContext
    {
        public DbSet<Award> Awards { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<CVApply> CVApplies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmployeeInCompany> EmployeeInCompanies { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Recuirter> Recuirters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Gender> Genders { get; set; }
        
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
