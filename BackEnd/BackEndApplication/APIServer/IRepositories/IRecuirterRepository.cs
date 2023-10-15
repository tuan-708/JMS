using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface IRecuirterRepository : IBaseRepository<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public Recuirter findByUserName(string? username);
        public bool checkExistUserNameEmail(string username, string email);
    }
}
