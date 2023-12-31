﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class Candidate
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
        public string Email { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public string? AvatarURL { get; set; }
        public virtual ICollection<CurriculumVitae>? CurriculumVitaes { get; set; }
        public virtual ICollection<CVMatching>? CVApplies { get; set; }
    }
}
