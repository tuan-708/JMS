using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly JMSDBContext context;

        public CategoryRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(Category data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Category data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return context.Categories
                .Where(x => !x.IsDelete)
                .ToList();
        }

        public List<Category> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
