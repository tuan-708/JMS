﻿using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.DTO.EntityDTO
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public int? RecuirterId { get; set; }
        public string Title { get; set; }
        public int? EmploymentTypeId { get; set; }
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
        public int? NumberRequirement { get; set; }
    }
}
