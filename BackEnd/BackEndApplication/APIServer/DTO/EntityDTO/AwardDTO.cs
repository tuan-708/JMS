using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class AwardDTO
    {
        public string AwardName { get; set; }
        public string? Description { get; set; }
        public int? FromYear { get; set; }
    }
}