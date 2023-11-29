using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly JMSDBContext _context;

        public AdminRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(Admin data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Admin data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _context.Candidates
                .Include(x => x.CurriculumVitaes)
                .Include(x => x.CVApplies).ToList();
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies
                .Include(x => x.Category)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.JobDescriptions)
                .Include(x => x.Recuirter)
                .ToList();
        }

        public List<CurriculumVitae> GetAllCVsByCandidateId(int candidateId)
        {
            return _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => x.CandidateId == candidateId)
                .ToList();
        }

        public List<JobDescription> GetAllJobsByRecruiterId(int recruiterId)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => x.RecuirterId == recruiterId)
                .ToList();
            return rs;
        }

        public List<Recuirter> GetAllRecruiters()
        {
            var rs = _context.Recuirters
                            .Include(x => x.Role)
                            .Include(x => x.EmployeeInCompanies)
                            .Include(x => x.Company)
                            .Include(x => x.Gender)
                            .OrderBy(x => x.FullName)
                            .ToList();
            return rs;
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidateById(int id)
        {
            return _context.Candidates
                .Include(x => x.CurriculumVitaes)
                .Include(x => x.CVApplies).FirstOrDefault(x => x.Id == id);
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies
                            .Include(x => x.Category)
                            .Include(x => x.EmployeeInCompanies)
                            .Include(x => x.JobDescriptions)
                            .Include(x => x.Recuirter)
                            .FirstOrDefault(x => x.CompanyId == id);
            ;
        }

        public CurriculumVitae GetCVById(int id)
        {
            return _context.CurriculumVitaes
                            .Include(x => x.Candidate)
                            .Include(x => x.Awards)
                            .Include(x => x.JobExperiences)
                            .Include(x => x.Educations)
                            .Include(x => x.Level)
                            .Include(x => x.Skills)
                            .Include(x => x.Projects)
                            .Include(x => x.Certificates)
                            .Include(x => x.EmploymentType)
                            .Include(x => x.Category)
                            .Include(x => x.Gender)
                            .FirstOrDefault(x => x.Id == id);
        }

        public JobDescription GetJDById(int id)
        {
            var rs = _context.JobDescriptions
                            .Include(x => x.Recuirter)
                            .Include(x => x.Level)
                            .Include(x => x.EmploymentType)
                            .Include(x => x.Company)
                            .Include(x => x.Category)
                            .Include(x => x.Gender)
                            .FirstOrDefault(x => x.JobId == id);
            return rs;
        }

        public Recuirter GetRecruiterById(int id)
        {
            var rs = _context.Recuirters
                .Include(x => x.Role)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.Company)
                .FirstOrDefault(x => x.Id == id);
            return rs;
        }

        public int Update(Admin data)
        {
            throw new NotImplementedException();
        }

        public int UpdateActiveStatus(int? recruiterId, int? candidateId)
        {
            if(recruiterId > 0)
            {
                Recuirter recruiter = _context.Recuirters.FirstOrDefault(x => x.Id == recruiterId);
                if(recruiter.IsActive) recruiter.IsActive = false;
                else recruiter.IsActive = true;
                return _context.SaveChanges();
            }
            if(candidateId > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.Id == candidateId);
                if(candidate.IsActive) candidate.IsActive = false;
                else candidate.IsActive = true;
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
