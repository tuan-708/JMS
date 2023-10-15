using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Skill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        public string Title { get; set; }
        public string SkillDescription { get; set; }
    }
}
