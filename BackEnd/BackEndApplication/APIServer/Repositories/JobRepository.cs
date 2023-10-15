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
            throw new NotImplementedException();
        }

        public int CreateById(JobDescription data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<JobDescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<JobDescription> GetAllById(int id)
        {
            return _context.JobPosts.FirstOrDefault(x => x.JobId == id);
        }

        public JobDescription GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(JobDescription data)
        {
            throw new NotImplementedException();
        }
    }
}
