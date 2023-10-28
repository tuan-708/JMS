using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using APIServer.Repositories;
using Newtonsoft.Json.Linq;
using AutoMapper;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using X.PagedList;
using X.PagedList;

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

        private readonly IJobRepository _jobRepo;
        private readonly IRecuirterRepository _recuirterRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PositionTitle> _positionTitleRepo;

        public JobService(IJobRepository jobRepo, IRecuirterRepository recuirterRepo, IConfiguration configuration, IMapper mapper, IBaseRepository<PositionTitle> positionTitleRepo)
        {
            _jobRepo = jobRepo;
            _recuirterRepo = recuirterRepo;
            _configuration = configuration;
            _mapper = mapper;
            _positionTitleRepo = positionTitleRepo;
        }

        public int Create(JobDescription data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(JobDescription? data, int recuirterId)
        {
            throw new NotImplementedException();
        }

        public int Delete(JobDescription data)
        {
            throw new NotImplementedException();
        }

        public List<JobDescription> getAll()
        {
            return _jobRepo.GetAll();
        }

        public List<JobDescription> getAllById(int id)
        {
            if (id <= 0) throw new Exception("Not exist");
            return _jobRepo.GetAllById(id);
        }

        public JobDescription? GetById(int id)
        {
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

        public PagingResponseBody<List<JobDTO>> GetJobsPaging(int? page, List<JobDTO> listData)
        {
            if (!listData.Any())
            {
                return new PagingResponseBody<List<JobDTO>>
                {
                    currentPage = 0,
                    message = GlobalStrings.SUCCESSFULLY,
                    ObjectLength = 0,
                    statusCode = System.Net.HttpStatusCode.OK,
                    TotalPage = 0,
                };
            }
            var numberInOnePage = int.Parse(_configuration["PageSize"]);
            var k = listData.Count;
            var totalPage = (int)Math.Ceiling((decimal)k / numberInOnePage);
            page = page <= 0 || page == null ? 1 : page;
            page = page > totalPage ? totalPage : page;
            var data = listData.ToPagedList((int)page, numberInOnePage).ToList();
            return new PagingResponseBody<List<JobDTO>>
            {
                currentPage = (int)page,
                message = GlobalStrings.SUCCESSFULLY,
                data = data,
                ObjectLength = k,
                statusCode = System.Net.HttpStatusCode.OK,
                TotalPage = totalPage,
            };
        }

        public List<JobDescription> getAllByCompany(int companyId)
        {
            return _jobRepo.getAllByCompanyId(companyId);
        }

        public List<JobDescription> getAllByRecuirter(int recuirterId)
        {
            return _jobRepo.getAllByRecuirterId(recuirterId);
        }

        public int deleteByRecuirterId(int? recuirterId, int JDid)
        {
            var jd = _jobRepo.GetById(JDid);
            if (!_recuirterRepo.checkExistById(recuirterId) || jd == null ||
                jd.RecuirterId != recuirterId)
            {
                throw new Exception("Not found");
            }
            jd.IsDelete = true;
            return _jobRepo.Update(jd);
        }

        public int deleteByCompanyId(int? companyId, int JDid)
        {
            throw new NotImplementedException();
        }

        public int updateByRecuirterId(int? recuirterId, JobDTO jobDTO)
        {
            var data = _mapper.Map<JobDescription>(jobDTO);
            var jd = _jobRepo.GetById(jobDTO.JobId);
            if (!_recuirterRepo.checkExistById(recuirterId) || jd == null ||
                jd.RecuirterId != recuirterId)
            {
                throw new Exception("Not found");
            }
            if (Validation.checkStringIsEmpty(data.Title, data.EducationRequirement,
                data.ExperienceRequirement, data.SkillRequirement, data.CandidateBenefit,
                data.Salary, data.ContactEmail, data.Address, data.JobDetail
                ))
            {
                throw new Exception("job not completed yet");
            }

            var newPosTitle = new List<PositionTitle>();
            if (jobDTO.PositionTitlesName.Any())
            {
                foreach (var item in jobDTO.PositionTitlesName)
                {
                    var pos = _positionTitleRepo.GetById((int)Validation.ConvertInt(item));
                    if (pos == null)
                        throw new Exception("Position title not exist");
                    newPosTitle.Add(pos);
                }
            }

            jd.Title = data.Title;
            jd.EmploymentTypeId = data.EmploymentTypeId;
            jd.GenderRequirement = data.GenderRequirement;
            jd.AgeRequirement = data.AgeRequirement;
            jd.EducationRequirement = data.EducationRequirement;
            jd.JobDetail = data.JobDetail;
            jd.ExperienceRequirement = data.ExperienceRequirement;
            jd.ProjectRequirement = data.ProjectRequirement;
            jd.SkillRequirement = data.SkillRequirement;
            jd.CertificateRequirement = data.CertificateRequirement;
            jd.OtherInformation = data.OtherInformation;
            jd.CandidateBenefit = data.CandidateBenefit;
            jd.Salary = data.Salary;
            jd.ContactEmail = data.ContactEmail;
            jd.Address = data.Address;
            jd.NumberRequirement = data.NumberRequirement;
            jd.PositionTitles = newPosTitle;
            jd.CategoryId = data.CategoryId;
            jd.CompanyId = data.CompanyId;

            return _jobRepo.Update(jd);
        }

        public int createById(JobDTO jobDTO, int? recuirterId)
        {
            var data = _mapper.Map<JobDescription>(jobDTO);
            if (recuirterId <= 0) throw new Exception("recuirter not exist");
            if (data == null) throw new Exception("JD not accepted");
            if (!_recuirterRepo.checkExistById(recuirterId))
            {
                throw new Exception("recuirter not exist");
            }
            if (Validation.checkStringIsEmpty(data.Title, data.EducationRequirement,
                data.ExperienceRequirement, data.SkillRequirement, data.CandidateBenefit,
                data.Salary, data.ContactEmail, data.Address, data.JobDetail
                ))
            {
                throw new Exception("job not completed yet");
            }

            var newPosTitle = new List<PositionTitle>();
            foreach (var item in jobDTO.PositionTitlesName)
            {
                var pos = _positionTitleRepo.GetById((int)Validation.ConvertInt(item));
                if (pos == null)
                    throw new Exception("Position title not exist");
                newPosTitle.Add(pos);
            }

            data.PositionTitles = newPosTitle;
            data.IsDelete = false;
            data.CreatedAt = DateTime.Now;
            data.ExpiredDate = DateTime.Now.AddDays(7);
            return _jobRepo.CreateById(data, recuirterId);
        }

        public List<int> GetVitaeListByMatching(int jobDesciptionId)
        {
            throw new NotImplementedException();
        }

        public int createById(JobDTO jobDTO, int recuirterId)
        {
            var data = _mapper.Map<JobDescription>(jobDTO);
            if (recuirterId <= 0) throw new Exception("recuirter not exist");
            if (data == null) throw new Exception("JD not accepted");
            if (!_recuirterRepo.checkExistById(recuirterId))
            {
                throw new Exception("recuirter not exist");
            }
            if (Validation.checkStringIsEmpty(data.Title, data.EducationRequirement,
                data.ExperienceRequirement, data.SkillRequirement, data.CandidateBenefit,
                data.Salary, data.ContactEmail, data.Address, data.JobDetail
                ))
            {
                throw new Exception("job not completed yet");
            }

            var newPosTitle = new List<PositionTitle>();
            foreach (var item in jobDTO.PositionTitlesName)
            {
                var pos = _positionTitleRepo.GetById((int)Validation.ConvertInt(item));
                if (pos == null)
                    throw new Exception("Position title not exist");
                newPosTitle.Add(pos);
            }

            data.PositionTitles = newPosTitle;
            data.IsDelete = false;
            data.CreatedAt = DateTime.Now;
            data.ExpiredDate = DateTime.Now.AddDays(7);
            return _jobRepo.CreateById(data, recuirterId);
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
