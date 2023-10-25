using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using APIServer.Repositories;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace APIServer.Services
{
    public class JobService : IJobService
    {
        private readonly IBaseRepository<JobDescription> _JDRepository;
        private readonly IBaseRepository<CurriculumVitae> _CVRepository;

        public JobService(IBaseRepository<JobDescription> JDRepository, IBaseRepository<CurriculumVitae> CVRepository)
        {
            _JDRepository = JDRepository;
            _CVRepository = CVRepository;
        }

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
                //Temperature = 0f,
                MaxTokens = 100,
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

        public List<int> GetVitaeListByMatching(int jobDesciptionId)
        {
            throw new NotImplementedException();
        }

        //public async List<int> GetVitaeListByMatching(int jobDesciptionId)
        //{
        //    JobDescription jobDescription = _JDRepository.GetById(jobDesciptionId);
        //    List<CurriculumVitae> vitaeList = _CVRepository.GetAll();

        //    foreach(CurriculumVitae curriculumVitae in vitaeList)
        //    {
        //        string rs = await GetResult(GPT_PROMPT.PromptForRecruiter(jobDescription, curriculumVitae));

        //        rs = Validation.processStringGpt(rs);

        //        JObject jsonObject = JObject.Parse(rs);


        //    }

        //    return null;
        //}


    }
}
