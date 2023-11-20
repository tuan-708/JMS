using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface ICurriculumVitaeService : IBaseService<CurriculumVitae>
    {
        public CurriculumVitae GetCurriculumVitaeByCandidateId(int candidateId, int CVid);
        public int UpdateCvByCandidateIdAndCvId(int candidateId, int cvId, CurriculumVitaeDTO cvDTO);
        public int ChangeCVStatus(int candidateId, int CVId);
    }
}
