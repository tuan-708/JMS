using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User Login(string? username, string? password);
        public User findByUserName(string? username);
        public bool checkExistUserNameEmail(string username, string email);
    }
}
