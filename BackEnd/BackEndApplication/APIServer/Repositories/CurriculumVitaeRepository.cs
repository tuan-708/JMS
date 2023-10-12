using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;

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
            User user = _context.users.FirstOrDefault(x => x.id == id);
            data.User = user;
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
            return _context.CurriculumVitaes.ToList();
        }

        public List<CurriculumVitae> GetAllById(int id)
        {
            return _context.CurriculumVitaes.Where(x => x.User != null ? x.User.id == id : x.User == null).ToList();
        }

        public CurriculumVitae GetById(int id)
        {
            CurriculumVitae? curriculumVitae = _context.CurriculumVitaes.FirstOrDefault(x => x.Id == id);
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
