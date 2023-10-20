using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class ProjectDTO
    {
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public bool IsStillWorking { get; set; }
    }
}