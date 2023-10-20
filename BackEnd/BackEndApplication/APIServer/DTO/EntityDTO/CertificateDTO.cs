using APIServer.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIServer.DTO.EntityDTO
{
    public class CertificateDTO
    {
        public string CertificateName { get; set; }
        public string? CertificateProvider { get; set; }
        public string? credentialURL { get; set; }
        public string? IssuedDate { get; set; }
        public string? ExpiredDate { get; set; }
    }
}