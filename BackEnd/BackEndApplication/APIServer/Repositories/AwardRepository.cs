using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class AwardRepository : IBaseListRepository<Award>
    {
        private readonly JMSDBContext context;

        public AwardRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int CreateList(List<Award> listAward, int cvId)
        {
            foreach(var o in listAward)
            {
                o.CurriculumVitaeId = cvId;
            }
            context.Awards.AddRange(listAward);
            return context.SaveChanges();
        }

        public int DeleteList(List<Award> data, int id)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAll(int cvId)
        {
            var rs = context.CurriculumVitaes
                .Include(x => x.Awards)
                .FirstOrDefault(x => x.Id == cvId && !x.IsDelete);
            if(rs  == null)
                throw new NullReferenceException("CV not exist");
            return rs.Awards.ToList();
        }

        public int UpdateList(List<Award> listAward, int id)
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.Awards)
                .FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if (cv == null)
            {
                throw new NullReferenceException("CV not exist");
            }
            cv.Awards = listAward;
            context.CurriculumVitaes.UpdateRange(cv);
            return context.SaveChanges();
        }
    }
}
