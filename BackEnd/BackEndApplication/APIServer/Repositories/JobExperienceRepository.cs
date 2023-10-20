using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class JobExperienceRepository : IBaseListRepository<JobExperience>

    {

        private readonly JMSDBContext context;

        public JobExperienceRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int CreateList(List<JobExperience> listExp, int cvId)
        {
            foreach (var o in listExp)
            {
                o.CurriculumVitaeId = cvId;
            }
            context.JobExperiences.AddRange(listExp);
            return context.SaveChanges();
        }

        public List<JobExperience> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<JobExperience> GetAll(int cvId)
        {
            var rs = context.CurriculumVitaes
                .Include(x => x.JobExperiences)
                .FirstOrDefault(x => x.Id == cvId && !x.IsDelete);
            if (rs == null)
                throw new NullReferenceException("CV not exist");
            return rs.JobExperiences.ToList();
        }

        public int UpdateList(List<JobExperience> listExp, int cvId)
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.JobExperiences)
                .FirstOrDefault(x => x.Id == cvId && !x.IsDelete);
            if (cv == null)
            {
                throw new NullReferenceException("CV not exist");
            }
            cv.JobExperiences = listExp;
            context.CurriculumVitaes.UpdateRange(cv);
            return context.SaveChanges();
        }
    }
}
