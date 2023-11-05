using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class Slider
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(500)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string? SubTitle { get; set; }
        public string? URL { get; set; }
        public int? Order { get; set; } = 0;
    }
}
