using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.Models.Entity
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<Recuirter> Recuirters { get; set;}
    }
}