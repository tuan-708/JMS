using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Award
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public virtual CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(500)]
        public string AwardName { get; set; }
        public int FromYear { get; set; }
    }
}
