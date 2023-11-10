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
        private readonly IRecuirterService _recuirterService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly JMSDBContext context;

        public RecuirterController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IRecuirterService recuirterService, IMapper mapper, IConfiguration config, JMSDBContext context)
        {
            _jobService = jobService;
            _curriculumVitaeService = curriculumVitaeService;
            _recuirterService = recuirterService;
            _mapper = mapper;
            _config = config;
            this.context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public BaseResponseBody<List<RecuirterDTO>> getAllRec()
        {
            try
            {
                var rs = _recuirterService.getAll();
                return new BaseResponseBody<List<RecuirterDTO>>
                {
                    statusCode = HttpStatusCode.OK,
                    message = GlobalStrings.SUCCESSFULLY,
                    data = _mapper.Map<List<RecuirterDTO>>(rs),
                };
            }
            catch (Exception e)
            {
                return new BaseResponseBody<List<RecuirterDTO>>
                {
                    statusCode = HttpStatusCode.BadRequest,
                    message = GlobalStrings.BAD_REQUEST,
                };
            }
        }

        [HttpGet]
        [Route("test-prompt")]
        public async Task<IActionResult> getTest(int jobDescriptionId, int CVId)
        {

            var job = context.JobDescriptions
               .Include(x => x.Recuirter)
               .Include(x => x.Level)
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
            string result = await GPT_PROMPT.GetResult(prompt) + Environment.NewLine;
            //float percent = Validation.checkPercentMatchingFromJSON(result);
            prompt += result + Environment.NewLine;

            return Ok(prompt);
        }

        [HttpGet]
        [Route("matching-cv")]
        public async Task<BaseResponseBody<List<CVApplyDTO>>> MatchingCV(int jobDescriptionId, int numberRequirement)
        {
            List<CVApplyDTO> cVApplies = _mapper.Map<List<CVApplyDTO>>(await _recuirterService.GetCVFromMatchingJD(jobDescriptionId, numberRequirement));

            return new BaseResponseBody<List<CVApplyDTO>>
            {
                statusCode = HttpStatusCode.OK,
                message = GlobalStrings.SUCCESSFULLY,
                data = _mapper.Map<List<CVApplyDTO>>(cVApplies),
            };
        }

        [HttpGet]
        [Route("get-estimate-date-to-matching")]
        public BaseResponseBody<string> GetEstimateDate(int jobId, DateTime dateRequirement)
        {
            string rs = _recuirterService.getEstimateDate(jobId, dateRequirement);

            return new BaseResponseBody<string>
            {
                statusCode = HttpStatusCode.OK,
                message = GlobalStrings.SUCCESSFULLY,
                data = rs,
            };
        }
    }
}
