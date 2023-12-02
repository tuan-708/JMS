using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JMSDBContext _context;

        public JobRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(JobDescription data)
        {
            _context.JobDescriptions.Add(data);
            return _context.SaveChanges();
        }

        public int CreateById(JobDescription data, int? recuirterId)
        {
            data.RecuirterId = recuirterId;
            _context.JobDescriptions.Add(data);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var job = _context.JobDescriptions.FirstOrDefault(x => x.JobId == id);
            if (job == null)
            {
                throw new NullReferenceException("JD not exist");
            }
            job.IsDelete = true;
            _context.JobDescriptions.Update(job);
            return _context.SaveChanges();
        }

        public List<JobDescription> GetAll()
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete && x.ExpiredDate > DateTime.Now)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return rs;
        }

        public List<JobDescription> getAllByCompanyId(int? companyId)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete && x.ExpiredDate > DateTime.Now &&
                x.CompanyId == companyId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return rs;
        }

        public List<JobDescription> GetAllById(int id)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete && x.ExpiredDate > DateTime.Now &&
                x.RecuirterId == id)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return rs;
        }

        public List<JobDescription> getAllByRecuirterId(int? recuirterId)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete && x.RecuirterId == recuirterId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return rs;
        }

        public List<JobDescription> getAllExpiredJD(int? recruiterId)
        {
            return _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => x.RecuirterId == recruiterId && x.ExpiredDate < DateTime.Now && x.IsDelete == false)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        public JobDescription GetById(int id)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.Level)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .FirstOrDefault(x => !x.IsDelete && x.JobId == id);
            return rs;
        }

        public int Update(JobDescription data)
        {
            _context.JobDescriptions.Update(data);
            return _context.SaveChanges();  
        }
    }
}
