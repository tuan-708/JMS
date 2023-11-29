using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AdminService(IAdminRepository adminContext, IMapper mapper, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(Admin data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Admin data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Admin data)
        {
            throw new NotImplementedException();
        }

        public List<Admin> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Admin> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _adminContext.GetAllCandidates();
        }

        public List<Company> GetAllCompanies()
        {
            return _adminContext.GetAllCompanies();
        }

        public List<CurriculumVitae> GetAllCVsByCandidateId(int candidateId)
        {
            return _adminContext.GetAllCVsByCandidateId(candidateId);
        }

        public List<JobDescription> GetAllJobsByRecruiterId(int recruiterId)
        {
            return _adminContext.GetAllJobsByRecruiterId(recruiterId);
        }

        public List<Recuirter> GetAllRecruiters()
        {
            return _adminContext.GetAllRecruiters();
        }

        public Admin? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidateById(int id)
        {
            return _adminContext.GetCandidateById(id);
        }

        public Company GetCompanyById(int id)
        {
            return _adminContext.GetCompanyById(id);
        }

        public CurriculumVitae GetCVById(int id)
        {
            return _adminContext.GetCVById(id);
        }

        public JobDescription GetJDById(int id)
        {
            return _adminContext.GetJDById(id);
        }

        public Recuirter GetRecruiterById(int id)
        {
            return _adminContext.GetRecruiterById(id);
        }

        public int Update(Admin data)
        {
            throw new NotImplementedException();
        }

        public int UpdateActiveStatus(int? recruiterId, int? candidateId)
        {
            return _adminContext.UpdateActiveStatus(recruiterId, candidateId);
        }
    }
}
