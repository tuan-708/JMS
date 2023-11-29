using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        public List<JobDescription> GetAllJobsByRecruiterId(int recruiterId);
        public List<CurriculumVitae> GetAllCVsByCandidateId(int candidateId);
        public List<Candidate> GetAllCandidates();
        public List<Recuirter> GetAllRecruiters();
        public List<Company> GetAllCompanies();
        public JobDescription GetJDById(int id);
        public CurriculumVitae GetCVById(int id);
        public Candidate GetCandidateById(int id);
        public Recuirter GetRecruiterById(int id);
        public Company GetCompanyById(int id);
        public int UpdateActiveStatus(int? recruiterId, int? candidateId);
        
    }
}
