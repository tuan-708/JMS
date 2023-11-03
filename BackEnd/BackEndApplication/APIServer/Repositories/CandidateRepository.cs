using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JMSDBContext context;

        public CandidateRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(Candidate data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Candidate data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate LoginCandidate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int Update(Candidate data)
        {
            context.Candidates.Update(data);
            return context.SaveChanges();
        }
    }
}
