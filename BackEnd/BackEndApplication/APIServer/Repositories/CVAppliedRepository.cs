using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class CVAppliedRepository : ICVApplyRepository
    {
        private readonly JMSDBContext _context;

        public CVAppliedRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(CVApply data)
        {
            _context.CVApplies.Add(data);
            return _context.SaveChanges();
        }

        public int CreateById(CVApply data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CVApply> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CVApply> GetAllByCandidateIdAndFromDataAndToDate(int candidateId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVApply> cVApplies = GetAllById(candidateId);
            if(fromDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate >= fromDate).ToList();
            if(toDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate <= toDate).ToList();

            return cVApplies;
        }

        public List<CVApply> GetAllById(int id)
        {
            List<CVApply> cVApplies = _context.CVApplies.Include(c => c.Candidate).Include(p => p.PositionTitle)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType)
                .Where(x => x.CandidateId == id).ToList();
            return cVApplies;
        }

        public List<CVApply> GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(int recruiterId, int? jobDescriptionId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVApply> cVApplies = _context.CVApplies.Include(c => c.Candidate).Include(p => p.PositionTitle)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType)
                .Where(x => x.JobDescription.Recuirter.Id == recruiterId).ToList();
            if(jobDescriptionId != null) cVApplies = cVApplies.Where(x => x.JobDescriptionId == jobDescriptionId).ToList();
            if(fromDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate >= fromDate).ToList();
            if(toDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate <= toDate).ToList();
            return cVApplies;
        }

        public CVApply GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(CVApply data)
        {
            _context.Update(data);
            return _context.SaveChanges();
        }
    }
}
