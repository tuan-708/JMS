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
        public string Title { get; set; }
        public string ComapanyName { get; set; }
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? EmploymentTypeId { get; set; }
        public EmploymentType? EmploymentType { get; set; }
    }
}
