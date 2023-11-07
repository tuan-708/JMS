using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICVApplyRepository : IBaseRepository<CVApply>
    {
        public List<CVApply> GetAllByCandidateIdAndFromDataAndToDate(int candidateId, DateTime? fromDate, DateTime? toDate);
        public List<CVApply> GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(int recruiterId, int? jobDescription, DateTime? fromDate, DateTime? toDate);
        public CVApply GetByCandidateIdAndCVAppliedId(int candidateId, int CVAppliedId);
        public CVApply GetByRecruiterIdAndCVAppliedId(int recuiterId, int CVAppliedId);
        public List<CVApply> GetByCVIdAndJobDescriptionId(int CVId, int jobDescriptionId);
        public CVApply GetByCVIdAndLastUpdateDate(int CVId, DateTime lastUpdateDate);
    }
}
