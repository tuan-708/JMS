using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class LevelRepository : IBaseRepository<Level>
    {
        private readonly JMSDBContext context;

        public LevelRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(Level data)
        {
            context.Levels.Add(data);
            return context.SaveChanges();
        }

        public int CreateById(Level data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Level> GetAll()
        {
            return context.Levels.ToList();
        }

        public List<Level> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Level GetById(int id)
        {
            return context.Levels.FirstOrDefault(x => x.Id == id && !x.IsDelete);
        }

        public int Update(Level data)
        {
            throw new NotImplementedException();
        }
    }
}
