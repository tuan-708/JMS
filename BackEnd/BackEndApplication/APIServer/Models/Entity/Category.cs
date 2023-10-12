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
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<CurriculumVitae> CurriculumVitaes { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}