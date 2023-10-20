using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class JobExperienceDTO
    {
        public string Title { get; set; }
        public string ComapanyName { get; set; }
        public string Location { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string? Description { get; set; }
        public string? EmploymentTypeName { get; set; }
    }
}