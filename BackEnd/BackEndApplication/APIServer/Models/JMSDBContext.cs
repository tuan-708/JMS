using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Models
{
    public class JMSDBContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }

        public JMSDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                id = 1,
                fullName = "super admin",
                userName = "admin",
                password = "admin",
                email = "admin@JMS.com",
                male = true,
                phoneNumber = "1234567890",
                dob = DateTime.Now,
                createdDate = DateTime.Now,
                lastUpdate = DateTime.Now,
                role = Role.Admin,
                isActive = true,
                isDelete = false,
                description = null,
            });
        }
    }
}
