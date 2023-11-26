using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class CurriculumVitaeRepository : ICurriculumVitaeRepository
    {
        private readonly JMSDBContext _context;

        public CurriculumVitaeRepository(JMSDBContext context)
        {
            _context = context;
        }

        public int Create(CurriculumVitae data)
        {
            _context.Add(data);
            return _context.SaveChanges();
        }

        public int CreateById(CurriculumVitae data, int? id)
        {
            //Recuirter user = _context.users.FirstOrDefault(x => x.id == id);
            //data.User = user;
            _context.Add(data);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes.FirstOrDefault(x => x.Id == id);
            if (curriculumVitae != null)
            {
                _context.Remove(curriculumVitae);
                return _context.SaveChanges();
            }
            return 0;
        }

        public List<CurriculumVitae> GetAll()
        {
            return _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete)
                .ToList();
        }

        public List<CurriculumVitae> GetAllByCategoryId(int? categoryId)
        {
            List<CurriculumVitae> curriculumVitaes = _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Gender)
                .Include(x => x.Category).Where(x => x.CategoryId == categoryId && x.IsFindingJob == true && !x.IsDelete).ToList();
            return curriculumVitaes;
        }

        public List<CurriculumVitae> GetAllById(int candidateId)
        {
            return _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .Where(x => !x.IsDelete && x.CandidateId == candidateId)
                .ToList();
        }

        public CurriculumVitae GetById(int id)
        {
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Category)
                .Include(x => x.Gender)
                .FirstOrDefault(x => x.Id == id);
            if (curriculumVitae != null)
                return curriculumVitae;
            return null;
        }

        public int Update(CurriculumVitae data)
        {
            _context.CurriculumVitaes.Update(data);
            return _context.SaveChanges();
        }

        public int UpdateIsDeleteStatus(int candidateId, int CVId)
        {
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes
                            .Include(x => x.Candidate)
                            .Include(x => x.Awards)
                            .Include(x => x.JobExperiences)
                            .Include(x => x.Educations)
                            .Include(x => x.Level)
                            .Include(x => x.Skills)
                            .Include(x => x.Projects)
                            .Include(x => x.Certificates)
                            .Include(x => x.EmploymentType)
                            .Include(x => x.Category)
                            .Include(x => x.Gender).FirstOrDefault(x => x.CandidateId == candidateId && x.Id == CVId);
            if (curriculumVitae != null)
            {
                curriculumVitae.IsDelete = true;
                return _context.SaveChanges();
            }
            return 0;
        }

        public int UpdateIsFindingJobStatus(int candidateId, int CVId)
        {
            List<CurriculumVitae> curriculumVitaes = _context.CurriculumVitaes
                .Include(x => x.Candidate)
                .Include(x => x.Awards)
                .Include(x => x.JobExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Level)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Include(x => x.Category)
                .Include(x => x.Gender).Where(x => x.CandidateId == candidateId && x.Id != CVId && x.IsFindingJob == true).ToList();
            if (curriculumVitaes != null && curriculumVitaes.Count > 0)
            {
                foreach (var curriculumVitae1 in curriculumVitaes)
                {
                    curriculumVitae1.IsFindingJob = false;
                    _context.SaveChanges();
                }
            }
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes
            .Include(x => x.Candidate)
            .Include(x => x.Awards)
            .Include(x => x.JobExperiences)
            .Include(x => x.Educations)
            .Include(x => x.Level)
            .Include(x => x.Skills)
            .Include(x => x.Projects)
            .Include(x => x.Certificates)
            .Include(x => x.EmploymentType)
            .Include(x => x.Category)
            .Include(x => x.Gender).FirstOrDefault(x => x.CandidateId == candidateId && x.Id == CVId);
            if (curriculumVitae != null)
            {
                if (curriculumVitae.IsFindingJob == true) curriculumVitae.IsFindingJob = false;
                else curriculumVitae.IsFindingJob = true;
                return _context.SaveChanges();
            }


            return 0;
        }
    }
}
