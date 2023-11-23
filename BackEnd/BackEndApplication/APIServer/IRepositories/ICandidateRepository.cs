using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        public Candidate LoginCandidate(string username, string password);
        public bool IsEmailExist(string email);
        public bool IsUsernameExist(string username);
        public int UpdatePassword(string email, string password);
        public int Register(string email, string fullName, string username, string password);
    }
}
