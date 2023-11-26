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
        public async Task<BaseResponseBody<string>> ApplyCV(int candidateId, int CVid, int jobDescriptionId)
        {
            try
            {
                int n = await _candidateService.ApplyJob(candidateId, CVid, jobDescriptionId);
                if(n == -1)
                {
                    return new BaseResponseBody<string>
                    {
                        message = "You applied this job already",
                        statusCode = HttpStatusCode.NoContent,
                    };
                }
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


        //[HttpGet("cv-applied-history")]
        //public PagingResponseBody<List<CVMatchingDTO>> GetCVAppliedHistory(int candidateId, string? fromDate, string? toDate, int? pageIndex)
        //{
        //    DateTime from = DateTime.MinValue;
        //    DateTime to = DateTime.Now;
        //    if (!String.IsNullOrEmpty(fromDate)) from = Validation.convertDateTime(fromDate);
        //    if (!String.IsNullOrEmpty(toDate)) to = Validation.convertDateTime(toDate);
        //    List<CVMatchingDTO> rs = _mapper.Map<List<CVMatchingDTO>>(_candidateService.GetCVAppliedHistory(candidateId, from, to));
        //    return _candidateService.GetCVAppliedHistoryPaging(pageIndex, rs);
        //}

        [HttpGet("get-all-cv-applied")]
        public PagingResponseBody<List<CVMatchingDTO>> GetCVAppliedHistory(int candidateId, int? pageIndex)
        {
            List<CVMatchingDTO> rs = _mapper.Map<List<CVMatchingDTO>>(_candidateService.GetCVApplied(candidateId));
            return _candidateService.GetCVAppliedHistoryPaging(pageIndex, rs);
        }

        [HttpGet("get-cv-applied-detail")]
        public BaseResponseBody<CVMatchingDTO> GetCVAppliedDetail(int candidateId, int CVAppliedId)
        {
            try
            {
                CVMatchingDTO cVApply = _mapper.Map<CVMatchingDTO>(_candidateService.GetCVAppliedDetail(candidateId, CVAppliedId));
                if (cVApply != null)
                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        data = cVApply,
                        message = GlobalStrings.SUCCESSFULLY,
                        statusCode = HttpStatusCode.OK,
                    };
                else
                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        data = null,
                        message = "CV doesn't exist",
                        statusCode = HttpStatusCode.NotFound,
                    };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<CVMatchingDTO>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
            
        }

        [HttpPost("update-profile")]
        public BaseResponseBody<CVMatchingDTO> UpdateProfile(int candidateId, string fullName, string phone, DateTime DOB, int genderId)
        {
            try
            {
                int n = _candidateService.UpdateProfile(candidateId, fullName, phone, DOB, genderId);
                if(n > 0)
                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        message = "update profile successfully",
                        statusCode = HttpStatusCode.OK,
                    };
                else
                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        message = "update profile failed",
                        statusCode = HttpStatusCode.BadRequest,
                    };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<CVMatchingDTO>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
