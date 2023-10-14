﻿using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using OpenAI_API;

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

        public  string GetResult(string prompt, IConfiguration configuration)
        {
            string apiKey = Validation.readKey();
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Model.DavinciText;
            completion.MaxTokens = 4000;
            //completion.Temperature = 0.2;
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

        public int CreateById(JobPost data, int id)
        {
            throw new NotImplementedException();
        }

        public JobPost? GetById(int id)
        {
            return context.GetById(id);
        }
    }
}
