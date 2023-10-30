using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public string? CreatedAt { get; set; }
    }
}
