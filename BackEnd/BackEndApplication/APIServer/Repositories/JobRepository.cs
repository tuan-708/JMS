using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class JobRepository : IBaseRepository<JobDescription>
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

        public int CreateById(JobDescription data, int id)
        {
            throw new NotImplementedException();
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
                .Include(x => x.PositionTitles)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Where(x => !x.IsDelete && x.ExpiredDate > DateTime.Now)
                .ToList();
            return rs;
        }

        public List<JobDescription> GetAllById(int id)
        {
            return _context.JobDescriptions.Where(x => x.JobId == id).ToList();
        }

        public JobDescription GetById(int id)
        {
            var rs = _context.JobDescriptions
                .Include(x => x.Recuirter)
                .Include(x => x.PositionTitles)
                .Include(x => x.EmploymentType)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .FirstOrDefault(x => !x.IsDelete && x.ExpiredDate > DateTime.Now && x.JobId == id);
            return rs;
        }

        public int Update(JobDescription data)
        {
            _context.JobDescriptions.Update(data);
            return _context.SaveChanges();  
        }
    }
}
