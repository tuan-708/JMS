using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class PositionTitleRepository : IBaseRepository<PositionTitle>
    {
        private readonly JMSDBContext context;

        public PositionTitleRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(PositionTitle data)
        {
            context.PositionTitles.Add(data);
            return context.SaveChanges();
        }

        public int CreateById(PositionTitle data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PositionTitle> GetAll()
        {
            return context.PositionTitles.ToList();
        }

        public List<PositionTitle> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public PositionTitle GetById(int id)
        {
            return context.PositionTitles.FirstOrDefault(x => x.Id == id && !x.IsDelete);
        }

        public int Update(PositionTitle data)
        {
            throw new NotImplementedException();
        }
    }
}
