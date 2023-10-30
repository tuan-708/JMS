using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;

namespace APIServer.IServices
{
    public interface ICompanyService : IBaseService<CompanyDTO>
    {
        public PagingResponseBody<List<CompanyDTO>> GetListPaging(int? page, List<CompanyDTO> listData);
        public int UpdateByRecuirterId(CompanyDTO data, int recuirterId);
        public int DeleteByRecuirterId(int recuirterId, int companyId);
        public List<CompanyDTO> GetAllByName(string? search);
    }
}
