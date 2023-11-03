using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        public Candidate LoginCandidate(string username, string password);
    }
}
