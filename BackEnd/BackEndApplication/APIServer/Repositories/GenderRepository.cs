using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class GenderRepository : IBaseRepository<Gender>
    {
        private readonly JMSDBContext _context;

        public GenderRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(Gender data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Gender data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetAll()
        {
            return _context.Genders.ToList();
        }

        public List<Gender> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Gender GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Gender data)
        {
            throw new NotImplementedException();
        }
    }
}
