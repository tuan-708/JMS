using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class JobRepository : IBaseRepository<JobPost>
    {
        private readonly JMSDBContext _context;

        public JobRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(JobPost data)
        {
            _context.JobPosts.Add(data);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var data = _context.JobPosts.FirstOrDefault(x => x.JobId == id);
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            data.IsDelete = true;
            _context.JobPosts.Update(data);
            return _context.SaveChanges();
        }

        public List<JobPost> GetAll()
        {
            var rs = _context.JobPosts
                .Include(x => x.User)
                .Include(x => x.Category)
                .Where(x => x.IsDelete == false && x.ExipredDate >= DateTime.Now)
                .ToList();
            return rs;
        }

        public List<JobPost> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public JobPost GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(JobPost data)
        {
            _context.JobPosts.Update(data);
            return _context.SaveChanges();
        }
    }
}
