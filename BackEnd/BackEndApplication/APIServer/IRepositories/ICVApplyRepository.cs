using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICVApplyRepository : IBaseRepository<CVApply>
    {
        public List<CVApply> GetAllByCandidateIdAndFromDataAndToDate(int candidateId, DateTime? fromDate, DateTime? toDate);
        public List<CVApply> GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(int recruiterId, int? jobDescription, DateTime? fromDate, DateTime? toDate);
    }
}
