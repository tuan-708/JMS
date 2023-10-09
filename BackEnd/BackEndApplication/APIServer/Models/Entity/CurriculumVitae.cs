using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class CurriculumVitae
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public string? Phone { get; set; }
        public string? DisplayName { get; set; }
        public bool Gender { get; set; }
        public string? DisplayEmail { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? LevelApply { get; set; }
        public string? Skills { get; set; }
        public string? Education { get; set; }
        public string? JobExperience { get; set; }
        public string? Activity { get; set; }
        public string? Award { get; set; }
        public string? Summary{ get; set; }
        public bool IsFinding { get; set; }
        public bool IsDelete { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }
    }
}
