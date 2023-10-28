using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class CVApply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public int? JobDescriptionId { get; set; }
        public virtual JobDescription? JobDescription { get; set; }
        [StringLength(2000)]
        public string? CareerGoal { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        [StringLength(200)]
        public string? DisplayName { get; set; }
        public bool IsMale { get; set; }
        [StringLength(100)]
        public string? DisplayEmail { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? Skill { get; set; }
        public string? Education { get; set; }
        public string? JobExperience { get; set; }
        public string? Project { get; set; }
        public string? Certificate { get; set; }
        public string? Award { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? PercentMatching { get; set; }
    }
}
