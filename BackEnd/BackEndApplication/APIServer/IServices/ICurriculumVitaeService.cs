using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface ICurriculumVitaeService : IBaseService<CurriculumVitae>
    {
        public CurriculumVitae GetCurriculumVitaeByCandidateId(int candidateId, int CVid);
    }
}
