using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IJobService : IBaseService<JobPost>
    {
        public int CreateNewPost(JobPost jobPost, int? userId);
    }
}
