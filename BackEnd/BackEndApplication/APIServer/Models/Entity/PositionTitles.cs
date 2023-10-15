using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.Models.Entity
{
    public class PositionTitle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<JobDescription>? JobDescriptions { get; set; }
        public virtual ICollection<CurriculumVitae>? CurriculumVitaes { get; set; }
        public virtual ICollection<CVApply>? CVApplies { get; set; }
    }
}
