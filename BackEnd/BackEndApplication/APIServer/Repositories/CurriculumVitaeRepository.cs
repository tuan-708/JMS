using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class CurriculumVitaeRepository : IBaseRepository<CurriculumVitae>
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

        public int CreateById(CurriculumVitae data, int id)
        {
            //Recuirter user = _context.users.FirstOrDefault(x => x.id == id);
            //data.User = user;
            _context.Add(data);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes.FirstOrDefault(x => x.Id == id);
            if(curriculumVitae != null)
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
                .Include(x => x.PositionTitle)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .Where(x => !x.IsDelete)
                .ToList();
        }

        public List<CurriculumVitae> GetAllById(int candidateId)
        {
            return _context.CurriculumVitaes
                //.Include(x => x.Candidate)
                //.Include(x => x.Awards)
                //.Include(x => x.JobExperiences)
                //.Include(x => x.Educations)
                //.Include(x => x.PositionTitle)
                //.Include(x => x.Skills)
                //.Include(x => x.Projects)
                //.Include(x => x.Certificates)
                //.Include(x => x.EmploymentType)
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
                .Include(x => x.PositionTitle)
                .Include(x => x.Skills)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.EmploymentType)
                .FirstOrDefault(x => x.Id == id);
            if( curriculumVitae != null )
                return curriculumVitae;
            return null;
        }

        public int Update(CurriculumVitae data)
        {
            _context.CurriculumVitaes.Update(data);
            return _context.SaveChanges();
        }
    }
}
