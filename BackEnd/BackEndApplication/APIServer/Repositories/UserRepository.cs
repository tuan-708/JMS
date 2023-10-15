using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public JMSDBContext context { get; set; }

        public bool checkExistUserNameEmail(string username, string email)
        {
            throw new NotImplementedException();
        }

        public int Create(Recuirter data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Recuirter data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter findByUserName(string? username)
        {
            throw new NotImplementedException();
        }

        public List<Recuirter> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Recuirter> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter Login(string? username, string? password)
        {
            throw new NotImplementedException();
        }

        public int Update(Recuirter data)
        {
            throw new NotImplementedException();
        }
    }
}
