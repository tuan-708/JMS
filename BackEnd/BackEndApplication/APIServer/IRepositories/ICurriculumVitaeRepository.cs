using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICurriculumVitaeRepository : IBaseRepository<CurriculumVitae>
    {
        public List<CurriculumVitae> GetAllByCategoryId(int? categoryId);
    }
}
