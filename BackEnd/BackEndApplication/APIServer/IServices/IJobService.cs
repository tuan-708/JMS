using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IJobService : IBaseService<JobDescription>
    {
        public int CreateNewPost(JobDescription jobPost, int? userId);
    }
}
