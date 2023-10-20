using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;

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

        public async Task<string> GetResult(string prompt)
        {
            string apiKey = Validation.readKey();
            var api = new OpenAIAPI(apiKey);
            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.GPT4,
                Temperature = 0f,
                MaxTokens = 50,
                Messages = new ChatMessage[] {
            new ChatMessage(ChatMessageRole.User, prompt)
        }
            });

            if (result != null)
            {
                var arr = result.Choices;
                var rs = "";
                foreach (var choice in arr)
                {
                    rs += choice.Message.Content;
                }
                return rs;
            }
            else
            {
                return "not found";
            }
        }
    }
}
