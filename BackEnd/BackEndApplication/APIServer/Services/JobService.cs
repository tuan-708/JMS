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
        private readonly IBaseRepository<JobPost> context;
        private readonly IUserRepository userRepository;

        public JobService(IBaseRepository<JobPost> context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public int Create(JobPost data)
        {
            throw new NotImplementedException();
        }

        public int Delete(JobPost data)
        {
            throw new NotImplementedException();
        }

        public List<JobPost> getAll()
        {
            var rs = context.GetAll();
            return rs;
        }

        public int Update(JobPost data)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetResult(string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 1000;
            var result = await openai.Completions.CreateCompletionAsync(completion);

            if (result != null && result.Completions.Count > 0)
            {
                answer = result.Completions[0].Text;
                return answer;
            }
            else
            {
                return null;
            }
        }

        public List<JobPost> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateNewPost(JobPost data, int? userId)
        {
            if (Validation.checkStringIsEmpty(
                data.EmailConnect, data.JobDescription, data.JobRequirement,
                data.JobType, data.Title, data.Address, data.SalaryMin, data.CandidateBenefit
                ))
            {
                throw new MissingFieldException("job not completed yet");
            }
            if (userId == null)
            {
                throw new Exception("user not exist");
            }
            var u = userRepository.GetById((int)userId);
            if(u.role == Role.User)
            {
                throw new Exception("account not have permission");
            }
            data.User = u;
            data.IsDelete = false;
            data.status = StatusJob.Finding;
            data.CreatedAt = DateTime.Now;
            data.ExipredDate = DateTime.Now.AddDays(7);
            return context.Create(data);
        }
    }
}
