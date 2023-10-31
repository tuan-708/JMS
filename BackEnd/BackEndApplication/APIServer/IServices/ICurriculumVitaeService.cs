using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface ICurriculumVitaeService : IBaseService<CurriculumVitae>
    {
        public CurriculumVitae GetCurriculumVitaeByCandidateId(int candidateId, int CVid);
        public int ApplyJob(int candaidateId, int CVid, int jobDescriptionId);
        public List<CVApply> GetCVAppliedHistory(int candaidateId, DateTime? fromDate, DateTime? toDate);
        public PagingResponseBody<List<CVApplyDTO>> GetCVAppliedHistoryPaging(int? page, List<CVApplyDTO> listData);
    }
}
