﻿using APIServer.IRepositories;
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

        public int Create(CVMatching data)
        {
            _context.Add(data);
            return _context.SaveChanges();
        }

        public int CreateById(CVMatching data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CVMatching> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CVMatching> GetAllByCandidateIdAndFromDataAndToDate(int candidateId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVMatching> cVApplies = GetAllById(candidateId);
            if(fromDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate >= fromDate).ToList();
            if(toDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate <= toDate).ToList();

            return cVApplies;
        }

        public List<CVMatching> GetAllById(int id)
        {
            List<CVMatching> cVApplies = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType)
                .Where(x => x.CandidateId == id).ToList();
            return cVApplies;
        }

        public List<CVMatching> GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(int recruiterId, int? jobDescriptionId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVMatching> cVApplies = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType)
                .Where(x => x.JobDescription.RecuirterId == recruiterId).ToList();
            if(jobDescriptionId != null) cVApplies = cVApplies.Where(x => x.JobDescriptionId == jobDescriptionId).ToList();
            if(fromDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate >= fromDate).ToList();
            if(toDate != null) cVApplies = cVApplies.Where(x => x.ApplyDate <= toDate).ToList();
            return cVApplies;
        }

        public CVMatching GetByCandidateIdAndCVAppliedId(int candidateId, int CVAppliedId)
        {
            CVMatching cVApply = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType).FirstOrDefault(x => x.CandidateId == candidateId && x.Id == CVAppliedId && x.IsApplied == true);
            return cVApply;
        }

        public List<CVMatching> GetByCVIdAndJobDescriptionId(int CVId, int jobDescriptionId)
        {
            List<CVMatching> cVApplyList = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType).Where(x => x.CurriculumVitaeId == CVId && x.JobDescriptionId == jobDescriptionId && x.IsReject == false).ToList();
            return cVApplyList != null ? cVApplyList : null;
        }

        public CVMatching GetByCVIdAndLastUpdateDate(int CVId, DateTime lastUpdateDate)
        {
            CVMatching cVApply = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType).FirstOrDefault(x => x.CurriculumVitaeId == CVId && x.LastUpdateDate == lastUpdateDate && x.IsReject == false);
            return cVApply != null ? cVApply : null;
        }

        public CVMatching GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CVMatching GetByRecruiterIdAndCVAppliedId(int recuiterId, int CVAppliedId)
        {
            CVMatching cVApply = _context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType).FirstOrDefault(x => x.JobDescription.RecuirterId == recuiterId && x.Id == CVAppliedId);
            return cVApply;
        }

        public int Update(CVMatching data)
        {
            _context.Update(data);
            return _context.SaveChanges();
        }
    }
}
