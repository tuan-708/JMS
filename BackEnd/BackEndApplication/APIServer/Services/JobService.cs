using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using OpenAI_API;
using OpenAI_API.Completions;

namespace APIServer.Services
{
    public class JobService : IJobService
    {
        public int Create(JobDescription data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(JobDescription data, int id)
        {
            throw new NotImplementedException();
        }

        public int CreateNewPost(JobDescription jobPost, int? userId)
        {
            throw new NotImplementedException();
        }

        public int Delete(JobDescription data)
        {
            throw new NotImplementedException();
        }

        public List<JobDescription> getAll()
        {
            throw new NotImplementedException();
        }

        public List<JobDescription> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetResult(string prompt, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public int Update(JobDescription data)
        {
            throw new NotImplementedException();
        }
    }
}
