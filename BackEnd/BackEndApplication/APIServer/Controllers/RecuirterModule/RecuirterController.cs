using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using APIServer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuirterController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ICurriculumVitaeService _curriculumVitaeService;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly JMSDBContext context;

        public RecuirterController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration, JMSDBContext jMSDBContext)
        {
            _jobService = jobService;
            _mapper = mapper;
            _config = configuration;
            _curriculumVitaeService = curriculumVitaeService;
            this.context = jMSDBContext;
        }

        [HttpGet]
        [Route("get-all")]
        public PagingResponseBody<List<JobDTO>> getAllPostJob()
        {
            //var rs = _mapper.Map<List<JobDTO>>(_jobService.getAll());
            var rs = context.JobDescriptions.ToList();
            return new PagingResponseBody<List<JobDTO>>
            {
                data = _mapper.Map<List<JobDTO>>(rs),
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                ObjectLength = rs.Count,
                TotalPage = rs.Count
            };
        }

        [HttpPost]
        [Route("new-post")]
        public async Task<BaseResponseBody<string>> createNewPost(JobDTO jobDTO)
        {
            try
            {
                var data = _mapper.Map<JobDescription>(jobDTO);
                data.CreatedAt = DateTime.Now;
                data.ExpiredDate = DateTime.Now.AddDays(7);
                data.IsDelete = false;
                data.PositionTitles = null;
                data.EmploymentTypeId = null;
                context.JobDescriptions.Add(data);
                return new BaseResponseBody<string>
                {
                    data = context.SaveChanges() + "",
                    //data = data.ToString(),
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpGet]
        [Route("test-prompt")]
        public async Task<IActionResult> getTest(int jobDescriptionId, int CVId)
        {

            var job = context.JobDescriptions
               .Include(x => x.Recuirter)
               .Include(x => x.PositionTitles)
               .Include(x => x.EmploymentType)
               .Include(x => x.Company)
               .Include(x => x.Category)
               .FirstOrDefault(x => x.JobId == jobDescriptionId);
            var cv = context.CurriculumVitaes
                .Include(x => x.JobExperiences)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.Awards)
                .FirstOrDefault(x => x.Id == CVId);
            string prompt = GPT_PROMPT.MatchingForRecruiter(job, cv);
            return Ok(prompt);
                
        }

        [HttpGet("test-cv")]
        public IActionResult test1()
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.JobExperiences)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.Awards)
                .FirstOrDefault();
            return Ok(cv);
        }

        
    }
}
