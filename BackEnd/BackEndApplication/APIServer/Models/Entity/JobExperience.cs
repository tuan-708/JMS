using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class JobExperience
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public CurriculumVitae? CurriculumVitae { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        [StringLength(500)]
        public string ComapanyName { get; set; }
        public string Location { get; set; }
        [StringLength(200)]
        public string FromDate { get; set; }
        [StringLength(200)]
        public string ToDate { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; }
        public int? EmploymentTypeId { get; set; }
        public EmploymentType? EmploymentType { get; set; }

        public override string? ToString()
        {
            return "Đã từng là: " + Title.Trim() + ", tại công ty: " + ComapanyName.Trim() + ", từ " + FromDate.Trim() + " đến " 
                + ToDate.Trim() + ", với vị trí: " + (EmploymentType?.Title == null ? "nhân viên tạm thời" : EmploymentType.Title.Trim()) +
                ", với mô tả như sau: ";
        }
    }
}
