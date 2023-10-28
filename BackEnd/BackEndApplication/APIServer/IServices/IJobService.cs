using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IJobService : IBaseService<JobDescription>
    {
        public List<int> GetVitaeListByMatching(int jobDesciptionId);
        public Task<string> GetResult(string prompt);
        public PagingResponseBody<List<JobDTO>> GetJobsPaging(int? page, List<JobDTO> listData);
        public List<JobDescription> getAllByCompany(int companyId);
        public List<JobDescription> getAllByRecuirter(int recuirterId);
        public int deleteByRecuirterId(int? recuirterId, int JDid);
        public int deleteByCompanyId(int? companyId, int JDid);
        public int updateByRecuirterId(int? recuirterId, JobDTO jdDTO);
        public int createById(JobDTO jobDTO, int recuirterId);
    }
}
