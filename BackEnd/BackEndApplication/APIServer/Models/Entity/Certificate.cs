using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class Certificate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(500)]
        public string CertificateName { get; set; }
        [StringLength(500)]
        public string CertificateProvider { get; set; }
        public string credentialURL { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
