using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class SkillDTO
    {
        public string Title { get; set; }
        public string? SkillDescription { get; set; }
    }
}