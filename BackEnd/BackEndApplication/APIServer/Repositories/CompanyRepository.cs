using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private readonly JMSDBContext context;

        public CompanyRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(Company data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Company data, int? id)
        {
            var recuirter = context.Recuirters.Any(x => x.Id == id);
            if (!recuirter)
            {
                throw new Exception("recuirter not exist");
            }
            data.RecuirterId = id;
            context.Companies.Add(data);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll()
        {
            return context.Companies
                .Include(x => x.Category)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.JobDescriptions)
                .Include(x => x.Recuirter)
                .Where(x => !x.IsDelete)
                .ToList();
        }

        public List<Company> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Company GetById(int id)
        {
            return context.Companies
                .Include(x => x.Category)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.JobDescriptions)
                .Include(x => x.Recuirter)
                .FirstOrDefault(x => !x.IsDelete && x.CompanyId == id)
                ;
        }

        public int Update(Company data)
        {
            context.Companies.Update(data);
            return context.SaveChanges();
        }
    }
}
