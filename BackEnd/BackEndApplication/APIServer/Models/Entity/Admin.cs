using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}
