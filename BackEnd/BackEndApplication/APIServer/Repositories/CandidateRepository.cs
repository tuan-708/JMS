using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

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
            return context.Candidates
                .Include(x => x.CurriculumVitaes)
                .Include(x => x.CVApplies)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsEmailExist(string email)
        {
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.Email.Trim().Equals(email.Trim()));
            return candidate != null;
        }

        public Candidate LoginCandidate(string username, string password)
        {
            return context.Candidates
                .Include(x => x.CurriculumVitaes)
                .Include(x => x.CVApplies)
                .FirstOrDefaultAsync(x => 
                x.UserName.ToLower() == username.ToLower() &&
                x.Password == password)
                .Result;
        }

        public int Update(Candidate data)
        {
            context.Candidates.Update(data);
            return context.SaveChanges();
        }

        public int UpdatePassword(string email, string password)
        {
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.Email.Equals(email));
            if(candidate != null)
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
                candidate.Password = hashPassword;
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
