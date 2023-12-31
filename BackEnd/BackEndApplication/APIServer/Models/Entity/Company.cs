﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string? Tax { get; set; }
        public int? YearOfEstablishment { get; set; }
        public string? WebURL { get; set; }
        public bool IsDelete { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<EmployeeInCompany>? EmployeeInCompanies { get; set; } 
        public virtual ICollection<JobDescription>? JobDescriptions { get; set; }
        public string? BackGroundURL { get; set; }
        public string? AvatarURL { get; set; }
        public int? RecuirterId { get; set; }
        public virtual Recuirter? Recuirter { get; set; }
        public string? Size { get; set; }
    }
}
