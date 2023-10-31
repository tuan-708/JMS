using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class EmployeeInCompanyRepository : IBaseRepository<EmployeeInCompany>
    {
        private readonly JMSDBContext context;

        public EmployeeInCompanyRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(EmployeeInCompany data)
        {
            context.EmployeeInCompanies.Add(data);
            return context.SaveChanges();
        }

        public int CreateById(EmployeeInCompany data, int? id)
        {
            data.CompanyId = id;
            context.EmployeeInCompanies.Add(data);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var data = context.EmployeeInCompanies.First(x => x.Id == id);
            context.EmployeeInCompanies.Remove(data);
            return context.SaveChanges();
        }

        public List<EmployeeInCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeInCompany> GetAllById(int id)
        {
            return context.EmployeeInCompanies
                .Include(x => x.Company)
                .Where(x => x.CompanyId == id)
                .ToList();
        }

        public EmployeeInCompany GetById(int id)
        {
            var data = context.EmployeeInCompanies
                .FirstOrDefault(x => x.Id == id);
            return data;
        }

        public int Update(EmployeeInCompany data)
        {
            context.EmployeeInCompanies.Update(data);
            return context.SaveChanges();
        }
    }
}
