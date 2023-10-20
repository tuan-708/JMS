using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(200)]
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        [StringLength(50)]
        public string? FromDate { get; set; }
        [StringLength(50)]
        public string? ToDate { get; set; }
        public bool IsStillWorking { get; set; }
    }
}
