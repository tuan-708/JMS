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

        public bool IsUsernameExist(string username)
        {
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.UserName.Trim().Equals(username.Trim()));
            return candidate != null;
        }

        public Candidate LoginCandidate(string username, string password)
        {
            Candidate data = context.Candidates
                .Include(x => x.CurriculumVitaes)
                .Include(x => x.CVApplies)
                .FirstOrDefaultAsync(x => 
                x.UserName.ToLower() == username.ToLower())
                .Result;
            if (VerifyPassword(password, data.Password))
                return data;
            return null;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public int Register(string email, string fullName, string username, string password)
        {
            Candidate candidate = new Candidate();
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(password.Trim());
            candidate.Email = email.Trim();
            candidate.Password = hashPassword;
            candidate.FullName = fullName.Trim();
            candidate.UserName = username.Trim();
            candidate.CreatedDate = DateTime.Now;
            candidate.IsActive = true;
            candidate.IsDelete = false;
            context.Candidates.Add(candidate);
            return context.SaveChanges();
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
