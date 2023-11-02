using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDescController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ICurriculumVitaeService _curriculumVitaeService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public JobDescController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration config)
        {
            _jobService = jobService;
            _curriculumVitaeService = curriculumVitaeService;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        [Route("get-all-jd/{page}")]
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
        [Route("all-jd-by-recuirter/{id}/{page}")]
        public PagingResponseBody<List<JobDTO>> getAllJDByRecuirterId(int id, int page)
        {
            var listJD = _mapper.Map<List<JobDTO>>(_jobService.getAllByRecuirter(id));
            return _jobService.GetJobsPaging(page, listJD);
        }

        [HttpGet]
        [Route("all-jd-by-company/{id}/{page}")]
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
                    statusCode = HttpStatusCode.OK,
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
