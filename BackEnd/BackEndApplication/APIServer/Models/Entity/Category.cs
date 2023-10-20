using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<CurriculumVitae> CurriculumVitaes { get; set; }
        public virtual ICollection<JobDescription> JobPosts { get; set; }
    }
}