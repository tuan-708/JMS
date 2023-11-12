using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Education
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(500)]
        public string SchoolName { get; set; }
        [StringLength(500)]
        public string? MajorName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [StringLength(200)]
        public string? FromYear { get; set; }
        [StringLength(200)]
        public string? ToYear { get; set; }
        public bool StillLearning { get; set; }
    }
}
