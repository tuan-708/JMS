using APIServer.Models.Entity;

namespace APIServer.DTO.EntityDTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int? RecuirterId { get; set; }
        public string? RecuirterName { get; set; }
        public string? StartDateDisplay { get; set; }
        public string? EndDateDisplay { get; set; }
        public bool IsWorking { get; set; }
    }
}
