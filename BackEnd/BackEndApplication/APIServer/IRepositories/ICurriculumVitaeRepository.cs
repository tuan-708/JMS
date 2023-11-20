using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICurriculumVitaeRepository : IBaseRepository<CurriculumVitae>
    {
        public List<CurriculumVitae> GetAllByCategoryId(int? categoryId);
        public int UpdateIsFindingJobStatus(int candidateId, int CVId);
    }
}
