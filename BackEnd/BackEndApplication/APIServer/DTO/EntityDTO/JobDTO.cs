using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class JobDTO
    {
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? LevelRequired { get; set; }
        public string? JobType { get; set; }
        public int? CategoryId { get; set; }
        public string? Address { get; set; }
        public string JobDescription { get; set; }
        public string JobRequirement { get; set; }
        public string? SalaryMin { get; set; }
        public string? SalaryMax { get; set; }
        public string? EmailConnect { get; set; }
        public string? Detail { get; set; }
        public string? status { get; set; }
    }
}
