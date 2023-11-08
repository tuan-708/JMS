using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
using APIServer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.CandidateModule
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICurriculumVitaeService _curriculumVitaeService;
        private readonly IJobService _jobService;
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;


        public CandidateController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration, ICandidateService candidateService)
        {
            _jobService = jobService;
            _curriculumVitaeService = curriculumVitaeService;
            _mapper = mapper;
            _config = configuration;
            _candidateService = candidateService;
        }

        [HttpGet("get-cv-by-id")]
        public PagingResponseBody<List<CurriculumVitaeDTO>> getAllCV(int userId)
        {
            var rs = _mapper.Map<List<CurriculumVitaeDTO>>(_curriculumVitaeService.getAllById(userId));
            return new PagingResponseBody<List<CurriculumVitaeDTO>>
            {
                data = rs,
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                ObjectLength = rs.Count,
                TotalPage = rs.Count
            };
        }

        [HttpPost("apply-cv")]
        public async Task<BaseResponseBody<string>> ApplyCV(int candaidateId, int CVid, int jobDescriptionId)
        {
            try
            {
                int n = await _candidateService.ApplyJob(candaidateId, CVid, jobDescriptionId);
                if(n > 0)
                {
                    return new BaseResponseBody<string>
                    {
                        data = "add successfully",
                        message = GlobalStrings.SUCCESSFULLY_SAVED,
                        statusCode = HttpStatusCode.OK,
                    };
                }
                else
                {
                    return new BaseResponseBody<string>
                    {
                        data = "add failed",
                        message = GlobalStrings.BAD_REQUEST,
                        statusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    data = ex.Message,
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }


        [HttpGet("cv-applied-history")]
        public PagingResponseBody<List<CVApplyDTO>> GetCVAppliedHistory(int candidateId, string? fromDate, string? toDate, int? pageIndex)
        {
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.Now;
            if (!String.IsNullOrEmpty(fromDate)) from = Validation.convertDateTime(fromDate);
            if (!String.IsNullOrEmpty(toDate)) to = Validation.convertDateTime(toDate);
            List<CVApplyDTO> rs = _mapper.Map<List<CVApplyDTO>>(_candidateService.GetCVAppliedHistory(candidateId, from, to));
            return _candidateService.GetCVAppliedHistoryPaging(pageIndex, rs);
        }

        [HttpGet("get-cv-by-candidate-id-and-cvapplied-id/{candidateId}/{CVAppliedId}")]
        public BaseResponseBody<CVApplyDTO> GetCVAppliedDetail(int candidateId, int CVAppliedId)
        {
            try
            {
                CVApplyDTO cVApply = _mapper.Map<CVApplyDTO>(_candidateService.GetCVAppliedDetail(candidateId, CVAppliedId));
                if (cVApply != null)
                    return new BaseResponseBody<CVApplyDTO>
                    {
                        data = cVApply,
                        message = GlobalStrings.SUCCESSFULLY,
                        statusCode = HttpStatusCode.OK,
                    };
                else
                    return new BaseResponseBody<CVApplyDTO>
                    {
                        data = null,
                        message = GlobalStrings.NOT_FOUND,
                        statusCode = HttpStatusCode.NotFound,
                    };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<CVApplyDTO>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
            
        }
    }
}
