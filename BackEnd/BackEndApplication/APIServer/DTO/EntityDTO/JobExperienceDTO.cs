using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class JobExperienceDTO
    {
        public string ComapanyName { get; set; }
        public string Position { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string? Description { get; set; }
        public string? EmploymentTypeName { get; set; }
    }
}