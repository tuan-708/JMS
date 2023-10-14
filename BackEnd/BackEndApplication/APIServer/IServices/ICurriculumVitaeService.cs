using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface ICurriculumVitaeService : IBaseService<CurriculumVitae>
    {
        public CurriculumVitae GetCurriculumVitae(int id);
    }
}
