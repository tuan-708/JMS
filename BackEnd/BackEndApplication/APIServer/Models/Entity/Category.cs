using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}