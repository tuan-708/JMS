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

        public CandidateController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper)
        {
            _jobService = jobService;
            _curriculumVitaeService = curriculumVitaeService;
            _mapper = mapper;
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
        public async Task<BaseResponseBody<string>> CreateCV(CurriculumVitaeDTO curriculumVitaeDTO)
        {
            try
            {
                string prompt = "tóm tắt thông tin dưới đây dưới dạng json object, với tên property chỉ bao gồm:" +
                    " Mô tả công việc, Yêu cầu ứng viên,  Địa điểm (Không thểm thắt, nếu property nào không có dữ liệu hãy để giá trị null)" +
                    " nội dung là nội dung trong thông tin, yêu cầu chính xác, ngắn gọn, không dài dòng, và tất cả đều là text nếu có xuống dòng" +
                    " hãy gộp đến khi thông tin còn 1 dòng và bỏ các dấu hiệu của dòng đó thay bằng dấu phẩy, không được chứa thêm property nhỏ bên trong,  " +
                    "tối đa và không được vượt quá 1500 chữ cái cho json object, nếu vượt quá phải làm lại:";
                var cv = _mapper.Map<CurriculumVitae>(curriculumVitaeDTO);
                _curriculumVitaeService.Create(cv);
                //string response = await _jobService.GetResult(prompt);
                return new BaseResponseBody<string>
                {
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
