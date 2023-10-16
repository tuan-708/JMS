using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using OpenAI_API;

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

        public JobDescription? GetById(int id)
        {
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public int Update(JobDescription data)
        {
            throw new NotImplementedException();
        }

        public string GetResult(string prompt)
        {
            string apiKey = Validation.readKey();
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Model.DavinciText;
            completion.MaxTokens = 1000;
            completion.Temperature = 0;
            var result = openai.Completions.CreateCompletionAsync(completion);

            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return answer;
            }
            else
            {
                return "not found";
            }
        }
    }
}
