using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class JobExperience
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(500)]
        public string ComapanyName { get; set; }
        public string Position { get; set; }
        [StringLength(200)]
        public string FromDate { get; set; }
        [StringLength(200)]
        public string ToDate { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; }
        public int? EmploymentTypeId { get; set; }
        public EmploymentType? EmploymentType { get; set; }
    }
}
