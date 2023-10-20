using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class CurriculumVitaeDTO
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string? CareerGoal { get; set; }
        public string? EmploymentTypeName { get; set; }
        public string? Phone { get; set; }
        public string? DisplayName { get; set; }
        public string Male { get; set; }
        public string? DisplayEmail { get; set; }
        public string? Address { get; set; }
        public string DOB { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdateDate { get; set; }
        public string? PositionTitle { get; set; }
        public List<JobExperienceDTO>? JobExperiences { get; set; }
        public List<SkillDTO>? Skills { get; set; }
        public List<EducationDTO>? Educations { get; set; }
        public List<ProjectDTO>? Projects { get; set; }
        public virtual List<CertificateDTO>? Certificates { get; set; }
        public List<AwardDTO>? Awards { get; set; }
    }
}
