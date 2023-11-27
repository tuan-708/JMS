using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface IJobRepository : IBaseRepository<JobDescription>
    {
        public List<JobDescription> getAllByRecuirterId(int? recuirterId);
        public List<JobDescription> getAllByCompanyId(int? companyId);
        public List<JobDescription> getAllExpiredJD(int? recruiterId);
    }
}
