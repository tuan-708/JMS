using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface ICandidateService :IBaseService<Candidate>
    {
        public Task<int> ApplyJob(int candaidateId, int CVid, int jobDescriptionId);
        public List<CVApply> GetCVAppliedHistory(int candaidateId, DateTime? fromDate, DateTime? toDate);
        public PagingResponseBody<List<CVApplyDTO>> GetCVAppliedHistoryPaging(int? page, List<CVApplyDTO> listData);
        public CVApply GetCVAppliedDetail(int candidateId, int CVAppliedId);
        public string LoginCandidate(string? userName, string? password);
    }
}
