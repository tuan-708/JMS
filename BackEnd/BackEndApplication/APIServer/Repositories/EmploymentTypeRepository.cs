using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class EmploymentTypeRepository : IBaseRepository<EmploymentType>
    {
        private readonly JMSDBContext context;

        public EmploymentTypeRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(EmploymentType data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(EmploymentType data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmploymentType> GetAll()
        {
            return context.EmploymentTypes
                .Where(x => !x.IsDelete)
                .ToList();    
        }

        public List<EmploymentType> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public EmploymentType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(EmploymentType data)
        {
            throw new NotImplementedException();
        }
    }
}
