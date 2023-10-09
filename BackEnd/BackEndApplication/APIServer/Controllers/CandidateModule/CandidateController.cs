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

        [HttpPost("create-cv")]
        public async Task<BaseResponseBody<string>> CreateCV(CurriculumVitaeDTO curriculumVitaeDTO, int userId)
        {
            try
            {
                string prompt = @"tóm tắt thông tin dưới đây dưới dạng JSON object, với tên property chỉ bao gồm 3 property: JobExperience, 
                    education, skill (Không thểm thắt, nếu property nào không có dữ liệu hãy để giá trị null, chỉ được sử dụng các property trên
                    không được thêm property khác) nội dung là nội dung trong thông tin, yêu cầu chính xác, ngắn gọn, không dài dòng, và tất cả nội dung
                    đều là text nếu có xuống dòng hãy gộp đến khi thông tin còn 1 dòng và bỏ các dấu hiệu của dòng đó thay bằng dấu phẩy. Không được chứa thêm 
                    property nhỏ bên trong các property lớn,  tối đa và không được vượt quá 1500 chữ cái cho json object, nếu vượt quá phải làm lại,
                    nếu nhiều hơn các property yêu cầu, phải làm lại:";
                var cv = _mapper.Map<CurriculumVitae>(curriculumVitaeDTO);
                string response = await _jobService.GetResult(prompt + "jobExperience: " + cv.JobExperience + ". education: " + cv.Education + ". skill: " + cv.Skills, _config);
                cv.Summary = response;
                _curriculumVitaeService.CreateById(cv, userId);
                return new BaseResponseBody<string>
                {
                    data = cv.Summary,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.Created,
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
    }
}
