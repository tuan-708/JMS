using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class CVApply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CurriculumVitaeId { get; set; }
        public virtual CurriculumVitae CurriculumVitae { get; set; }
        public int JobPostId { get; set; }
        public virtual JobPost JobPost { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
