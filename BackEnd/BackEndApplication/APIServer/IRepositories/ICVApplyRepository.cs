using APIServer.Models.Entity;

namespace APIServer.IRepositories
{
    public interface ICVApplyRepository : IBaseRepository<CVMatching>
    {
        public List<CVMatching> GetAllByCandidateIdAndFromDataAndToDate(int candidateId, DateTime? fromDate, DateTime? toDate);
        public List<CVMatching> GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(int recruiterId, int? jobDescription, DateTime? fromDate, DateTime? toDate);
        public CVMatching GetByCandidateIdAndCVAppliedId(int candidateId, int CVAppliedId);
        public CVMatching GetByRecruiterIdAndCVAppliedId(int recuiterId, int CVAppliedId);
        public List<CVMatching> GetByCVIdAndJobDescriptionId(int CVId, int jobDescriptionId);
        public CVMatching GetByCVIdAndLastUpdateDate(int CVId, DateTime lastUpdateDate);
    }
}
