namespace APIServer.DTO.EntityDTO
{
    public class CVApplyDTO
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public CandidateDTO? Candidate { get; set; }
        public int? JobDescriptionId { get; set; }
        public virtual JobDTO? JobDescription { get; set; }
        public string? CareerGoal { get; set; }
        public string? Phone { get; set; }
        public string? DisplayName { get; set; }
        public bool IsMale { get; set; }
        public string? DisplayEmail { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? Skill { get; set; }
        public string? Education { get; set; }
        public string? JobExperience { get; set; }
        public string? Project { get; set; }
        public string? Certificate { get; set; }
        public string? Award { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? PercentMatching { get; set; }
        public virtual PositionTitleDTO? PositionTitle { get; set; }
        public string? CategoryName { get; set; }
    }
}
