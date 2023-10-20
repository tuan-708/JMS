using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class CurriculumVitae
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
        [StringLength(1000)]
        public string? CareerGoal { get; set; }
        public int? EmploymentTypeId { get; set; }
        public virtual EmploymentType? EmploymentType { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        [StringLength(200)]
        public string? DisplayName { get; set; }
        public bool IsMale { get; set; }
        [StringLength(200)]
        public string? DisplayEmail { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? PositionTitleId { get; set; }
        public virtual PositionTitle? PositionTitle { get; set; }
        public bool IsActive { get; set;}
        public bool IsDelete { get; set;}
        public virtual ICollection<JobExperience>? JobExperiences { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
        public virtual ICollection<Education>? Educations { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<Certificate>? Certificates { get; set; }
        public virtual ICollection<Award>? Awards { get; set; }
    }
}
