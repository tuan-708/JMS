using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface IRecuirterRepository : IBaseRepository<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public Recuirter findByUserName(string? username);
        public bool checkExistUserNameEmail(string username, string email);
        public bool checkExistById(int? recuirterId);
        public bool IsEmailExist(string email);
        public bool IsUsernameExist(string username);
        public int UpdatePassword(string email, string password);
        public int Register(string email, string fullName, string username, string password);

    }
}
