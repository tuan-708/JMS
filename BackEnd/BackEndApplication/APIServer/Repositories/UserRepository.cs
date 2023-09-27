using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public JMSDBContext context { get; set; }

        public UserRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(User data)
        {
            context.users.Add(data);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return context.users.ToList();
        }

        public User GetById(int id)
        {
            return context.users
                .Where(x => x.isDelete == false)
                .FirstOrDefault(x => x.id == id);
        }

        public User Login(string? username, string? password)
        {
            return context.users
                .Where(x => x.isActive == true && 
                x.isDelete == false &&
                x.userName == username && 
                x.password == password)
                .FirstOrDefault();
        }

        public int Update(User data)
        {
            context.users.Update(data);
            return context.SaveChanges();
        }

        public User findByUserName(string? username)
        {
            return context.users
                .Where(x => x.isActive == true &&
                x.isDelete == false &&
                x.userName == username)
                .FirstOrDefault();
        }
    }
}
