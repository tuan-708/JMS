using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.Models.Entity
{
    public class Recuirter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [AllowNull]
        public bool IsMale { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [AllowNull]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [AllowNull]
        public int? CreatedBy { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<EmployeeInCompany> EmployeeInCompanies { get; set; }
        public string? AvatarURL { get; set; }
    }
}
