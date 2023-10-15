﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class JobDescription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public int? RecuirterId { get; set; }
        public virtual Recuirter? Recuirter { get; set; }
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        public virtual ICollection<PositionTitle>? PositionTitles { get; set; }
        public int? EmploymentTypeId { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public string? GenderRequirement { get; set; }
        public string? AgeRequirement { get; set; }
        public string? EducationRequirement { get; set; }
        public string? JobDetail { get; set; }
        public string? ExperienceRequirement { get; set; }
        public string? ProjectRequirement { get; set; }
        public string? SkillRequirement { get; set; }
        public string? CertificateRequirement { get; set; }
        public string? OtherInformation { get; set; }
        public string? CandidateBenefit { get; set; }
        public string? Salary { get; set; }
        public string? ContactEmail { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsDelete { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
