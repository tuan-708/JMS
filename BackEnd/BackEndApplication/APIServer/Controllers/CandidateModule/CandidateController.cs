using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;


        public CandidateController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration)
        {
            _jobService = jobService;
            _curriculumVitaeService = curriculumVitaeService;
            _mapper = mapper;
            _config = configuration;
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
        public BaseResponseBody<string> ApplyCV(int candaidateId, int CVid, int jobDescriptionId)
        {
            try
            {
                int n = _curriculumVitaeService.ApplyJob(candaidateId, CVid, jobDescriptionId);
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
            List<CVApplyDTO> rs = _mapper.Map<List<CVApplyDTO>>(_curriculumVitaeService.GetCVAppliedHistory(candidateId, from, to));
            return _curriculumVitaeService.GetCVAppliedHistoryPaging(pageIndex, rs);
        }
    }
}
