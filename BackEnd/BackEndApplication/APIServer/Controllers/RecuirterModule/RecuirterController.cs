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
using System.Collections.Generic;
using System.Net;
using X.PagedList;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuirterController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ICurriculumVitaeService _curriculumVitaeService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
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
        public PagingResponseBody<List<JobDTO>> getAllPostJob(int? page)
        {
            var listJob = _mapper.Map<List<JobDTO>>(_jobService.getAll());
            return _jobService.GetJobsPaging(page, listJob);
        }

        [HttpPost]
        [Route("new-post/{recuirterId}")]
        public async Task<BaseResponseBody<string>> createNewJD(int recuirterId, JobDTO jobDTO)
        {
            try
            {
                var count = _jobService.createById(jobDTO, recuirterId);
                return new BaseResponseBody<string>
                {
                    data = count.ToString(),
                    statusCode = HttpStatusCode.Created,
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    message = ex.Message,
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
            string prompt = GPT_PROMPT.PromptForCandidate(job, cv) + Environment.NewLine;
            //string result = await _jobService.GetResult(prompt) + Environment.NewLine;
            //float percent = Validation.checkPercentMatchingFromJSON(result);
            //prompt += result + Environment.NewLine;

            return Ok(prompt);
        }

        [HttpGet]
        [Route("by-recuirter/{id}/{page}")]
        public PagingResponseBody<List<JobDTO>> getAllJDByRecuirterId(int id, int page)
        {
            var listJD = _mapper.Map<List<JobDTO>>(_jobService.getAllByRecuirter(id));
            return _jobService.GetJobsPaging(page, listJD);
        }

        [HttpGet]
        [Route("by-company/{id}/{page}")]
        public PagingResponseBody<List<JobDTO>> getAllJDByCompany(int id, int page)
        {
            var listJD = _mapper.Map<List<JobDTO>>(_jobService.getAllByCompany(id));
            return _jobService.GetJobsPaging(page, listJD);
        }

        [HttpPost]
        [Route("delete-jd/{recuirterId}/{jobId}")]
        public BaseResponseBody<int> deleteJDByRecuirter(int recuirterId, int jobId)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = _jobService.deleteByRecuirterId(recuirterId, jobId),
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("update-jd/{recuirterId}")]
        public BaseResponseBody<int> updateByRecuirter(int recuirterId,
            [FromBody] JobDTO jobDTO)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY,
                    data = _jobService.updateByRecuirterId(recuirterId, jobDTO),
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    message = ex.Message,
                    data = -1,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
