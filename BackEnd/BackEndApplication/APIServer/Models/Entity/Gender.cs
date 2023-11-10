using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class Gender
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<JobDescription>? JobDescriptions { get; set; }
        public virtual ICollection<Candidate>? Candidates { get; set; }
        public virtual ICollection<Recuirter>? Recuirters { get; set; }
        public virtual ICollection<CurriculumVitae>? CurriculumVitaes { get; set; }
        public virtual ICollection<CVMatching>? CVApplies { get; set; }
    }
}
