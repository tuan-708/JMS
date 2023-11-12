using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class EducationDTO
    {
        public string SchoolName { get; set; }
        public string? MajorName { get; set; }
        public string? Description { get; set; }
        public string? FromYear { get; set; }
        public string? ToYear { get; set; }
        public bool StillLearning { get; set; }
    }
}