using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class RecuirterRepository : IRecuirterRepository
    {
        public JMSDBContext context { get; set; }

        public RecuirterRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public bool checkExistUserNameEmail(string username, string email)
        {
            var data = context.Recuirters
                .Where(x => x.UserName.ToLower() == username.ToLower()
                && x.Email.ToLower() == email.ToLower()).ToArray();
            return data.Length > 0;
        }

        public int Create(Recuirter data)
        {
            context.Recuirters.Add(data);
            return context.SaveChanges();
        }

        public int CreateById(Recuirter data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var data = context.Recuirters
                .FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if(data == null)
            {
                throw new NullReferenceException("Recuirter not exist");
            }
            data.IsDelete = true;
            context.Recuirters.Update(data);
            return context.SaveChanges();
        }

        public Recuirter findByUserName(string? username)
        {
            return context.Recuirters
                .FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
        }

        public List<Recuirter> GetAll()
        {
            var rs = context.Recuirters
                .Include(x => x.Role)
                .Include(x => x.EmployeeInCompanies)
                .Where(x => !x.IsDelete)
                .ToList();
            return rs;
        }

        public List<Recuirter> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter GetById(int id)
        {
            var rs = context.Recuirters
                .Include(x => x.Role)
                .Include(x => x.EmployeeInCompanies)
                .FirstOrDefault(x => !x.IsDelete && x.Id == id);
            return rs;
        }

        public Recuirter Login(string? username, string? password)
        {
            var data = context.Recuirters
                .FirstOrDefault(x => x.UserName.ToLower() == username.ToLower()
                && x.Password == password);
            return data;
        }

        public int Update(Recuirter data)
        {
            context.Recuirters.Update(data);
            return context.SaveChanges();
        }

        public bool checkExistById(int? recuirterId)
        {
            return context.Recuirters.Where(x => x.Id == recuirterId).Any();
        }
    }
}
