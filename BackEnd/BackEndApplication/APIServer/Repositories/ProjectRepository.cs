using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class ProjectRepository : IBaseListRepository<Project>
    {
        private readonly JMSDBContext context;

        public ProjectRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int CreateList(List<Project> projects, int cvId)
        {
            foreach (var o in projects)
            {
                o.CurriculumVitaeId = cvId;
            }
            context.Projects.AddRange(projects);
            return context.SaveChanges();
        }

        public int DeleteList(List<Project> data, int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll(int cvId)
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.Projects)
                .FirstOrDefault(x => x.Id == cvId && !x.IsDelete);
            if (cv == null)
                throw new NullReferenceException("CV not exist");
            return cv.Projects.ToList();
        }

        public int UpdateList(List<Project> projects, int cvId)
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.Projects)
                .FirstOrDefault(x => x.Id == cvId && !x.IsDelete);
            if (cv == null)
                throw new NullReferenceException("CV not exist");
            cv.Projects = projects;
            context.CurriculumVitaes.Update(cv);
            return context.SaveChanges();
        }
    }
}
