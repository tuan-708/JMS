using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IRecuirterService : IBaseService<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public string generateToken(Recuirter? userInfo);
        public Recuirter getById(int? id);
        public int CreateRecuirterAccount(Recuirter? account);
        public List<CVApply> GetCVAppliedHistory(int recruiterId, int? jobDescriptionId, DateTime? fromDate, DateTime? toDate);
        public PagingResponseBody<List<CVApplyDTO>> GetCVAppliedHistoryPaging(int? page, List<CVApplyDTO> listData);
        public CVApply GetCVAppliedDetail(int recuiterId, int CVAppliedId);
        public Task<List<CVApply>> GetCVFromMatchingJD(int jobDescriptionId, int numberRequirement);
    }
}
