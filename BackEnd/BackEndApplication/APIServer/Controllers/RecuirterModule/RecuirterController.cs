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

        public RecuirterController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration, JMSDBContext jMSDBContext, IRecuirterService recuirterService)
        {
            _jobService = jobService;
            _mapper = mapper;
            _config = configuration;
            _curriculumVitaeService = curriculumVitaeService;
            this.context = jMSDBContext;
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

    }
}
