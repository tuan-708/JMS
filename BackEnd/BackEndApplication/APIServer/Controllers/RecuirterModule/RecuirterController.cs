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
        [Route("get-all-cv-matched-by-number-requirement")]
        public PagingResponseBody<List<CVMatchingDTO>> GetCVMatchedByNumberRequirement(int recruiterId, int jobDescriptionId, int? pageIndex)
        {
            List<CVMatchingDTO> rs = _mapper.Map<List<CVMatchingDTO>>(_recuirterService.GetCVMatchedByNumberRequirement(recruiterId, jobDescriptionId));
            return _recuirterService.GetCVPaging(pageIndex, rs);
        }

        [HttpGet]
        [Route("get-all-cv-matched-left")]
        public PagingResponseBody<List<CVMatchingDTO>> GetCVMatchedLeft(int recruiterId, int jobDescriptionId, int? pageIndex)
        {
            List<CVMatchingDTO> rs = _mapper.Map<List<CVMatchingDTO>>(_recuirterService.GetCVMatchedLeft(recruiterId, jobDescriptionId));
            return _recuirterService.GetCVPaging(pageIndex, rs);
        }

        [HttpGet]
        [Route("get-all-cv-selected")]
        public PagingResponseBody<List<CVMatchingDTO>> GetCVSelected(int recruiterId, int jobDescriptionId, int? pageIndex)
        {
            List<CVMatchingDTO> rs = _mapper.Map<List<CVMatchingDTO>>(_recuirterService.GetCVSelected(recruiterId, jobDescriptionId));
            return _recuirterService.GetCVPaging(pageIndex, rs);
        }

        [HttpPost]
        [Route("matching-job")]
        public async Task<BaseResponseBody<List<CVMatchingDTO>>> MatchingJob(int recruiterId, int jobDescriptionId, int numberRequirement)
        {
            List<CVMatchingDTO> cVApplies = _mapper.Map<List<CVMatchingDTO>>(await _recuirterService.GetCVFromMatchingJD(recruiterId, jobDescriptionId, numberRequirement));

            return new BaseResponseBody<List<CVMatchingDTO>>
            {
                statusCode = HttpStatusCode.OK,
                message = GlobalStrings.SUCCESSFULLY,
                data = _mapper.Map<List<CVMatchingDTO>>(cVApplies),
            };
        }

        [HttpPost]
        [Route("update-cv-selected-status")]
        public BaseResponseBody<string> UpdateCVSelectedStatusd(int recruiterId, int jobDescriptionId, int CVMatchingId)
        {
            int n = _recuirterService.UpdateCVSelectedStatus(recruiterId, jobDescriptionId, CVMatchingId);
            if (n > 0)
            {
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.OK,
                    message = "update successfully",
                };
            }

            return new BaseResponseBody<string>
            {
                statusCode = HttpStatusCode.BadRequest,
                message = "update failed",
            };
        }

        [HttpGet]
        [Route("get-cv-matching-detail")]
        public BaseResponseBody<CVMatchingDTO> GetCVMatchingDetail(int recruiterId, int jobDescriptionId, int CVMatchingId)
        {
            try
            {
                CVMatching CVMatching = _recuirterService.GetCVMatchingDetail(recruiterId, jobDescriptionId, CVMatchingId);
                var CVMatchingDTO = _mapper.Map<CVMatchingDTO>(CVMatching);
                if (CVMatchingDTO != null)

                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        data = CVMatchingDTO,
                        statusCode = HttpStatusCode.OK,
                        message = "get CV successfully",
                    };
                else
                    return new BaseResponseBody<CVMatchingDTO>
                    {
                        data = CVMatchingDTO,
                        statusCode = HttpStatusCode.NotFound,
                        message = "CV doesn't exist",
                    };
            } catch (Exception ex)
            {
                return new BaseResponseBody<CVMatchingDTO>
                {
                    message = ex.Message.ToString(),
                };
            }
            
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
