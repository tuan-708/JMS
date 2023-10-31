using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class EmploymentTypeDTO
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
    }
}
