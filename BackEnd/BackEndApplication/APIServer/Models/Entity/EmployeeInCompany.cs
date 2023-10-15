namespace APIServer.Models.Entity
{
    public class EmployeeInCompany
    {
        public int Id { get; set; }
        public int? RecuirterId { get; set; }
        public virtual Recuirter? Recuirter { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsWorking { get; set; }
    }
}
