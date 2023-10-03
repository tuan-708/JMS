using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.DTO.EntityDTO
{
    public class UserDTO
    {
        public string? fullName { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public bool? male { get; set; }
        public string? phoneNumber { get; set; }
        public string? dobStr { get; set; }
        public string? createdDate { get; set; }
        public string? lastUpdate { get; set; }
        public string? description { get; set; }
        public string? roleName { get; set; }
        public int? createdBy { get; set; }
        public bool? isActive { get; set; }
    }
}
