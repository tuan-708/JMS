using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.Models.Entity
{
    [Table("User")]
    public class User
    {
        [Column("user_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("Full_Name")]
        [Required]
        [StringLength(100)]
        public string fullName { get; set; }
        [Column("User_Name")]
        [Required]
        [StringLength(100)]
        public string userName { get; set; }
        [Column("Email")]
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Column("Password")]
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        [Column("Is_Male")]
        [AllowNull]
        public bool male { get; set; }
        [Column("Phone_Number")]
        [Required]
        [StringLength(10)]
        public string phoneNumber { get; set; }
        [Column("DOB")]
        [AllowNull]
        public DateTime dob { get; set; }
        [Column("Created_Date")]
        [Required]
        public DateTime createdDate { get; set; }
        [Column("Last_Date")]
        [Required]
        public DateTime lastUpdate { get; set; }
        [Column("Description")]
        [AllowNull]
        public string? description { get; set; }
        [Column("Created_By")]
        [AllowNull]
        public int? createdBy { get; set; }
        public Role role { get; set; }
        [Column("Is_Active")]
        public bool isActive { get; set; }
        [Column("Is_Delete")]
        public bool isDelete { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
