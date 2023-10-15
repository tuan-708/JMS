using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
using APIServer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuirterController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public RecuirterController(IJobService jobService, IMapper mapper, IConfiguration configuration)
        {
            _jobService = jobService;
            _mapper = mapper;
            _config = configuration;
        }

        [HttpGet]
        [Route("get-all")]
        public PagingResponseBody<List<JobDTO>> getAllPostJob()
        {
            var rs = _mapper.Map<List<JobDTO>>(_jobService.getAll());
            return new PagingResponseBody<List<JobDTO>>
            {
                data = rs,
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                ObjectLength = rs.Count,
                TotalPage = rs.Count
            };
        }

        [HttpPost]
        [Route("new-post")]
        public async Task<BaseResponseBody<string>> createNewPost(JobDTO jobDTO)
        {
            try
            {
                //string prompt = @"tóm tắt thông tin dưới đây dưới dạng json object, với tên property chỉ bao gồm: jobDescription, jobRequirment,  Address 
                //    (Không thểm thắt, nếu property nào không có dữ liệu hãy để giá trị null) nội dung là nội dung trong thông tin, yêu cầu chính xác, ngắn gọn, không dài dòng, 
                //    và tất cả đều là text nếu có xuống dòng hãy gộp đến khi thông tin còn 1 dòng và bỏ các dấu hiệu của dòng đó thay bằng dấu phẩy, không được chứa thêm 
                //    property nhỏ bên trong, tối đa và không được vượt quá 1500 chữ cái cho json object, chỉ yêu cầu đáp án
                //    không cần phải giải thích hoặc có bất kì kí tự nào khác ngoài json object đã yêu cầu, nếu không đáp ứng được phải làm lại:";
                //var job = _mapper.Map<JobDescription>(jobDTO);
                //string response = await _jobService.GetResult(prompt + " jobDescription:" + job.JobDescription + ". jobRequirment:" + job.JobRequirement + ". address:" + job.Address, _config);
                //job.Summary = response;
                //_jobService.CreateNewPost(job, jobDTO.UserId);
                //return new BaseResponseBody<string>
                //{
                //    data = job.Summary,
                //    message = GlobalStrings.SUCCESSFULLY_SAVED,
                //    statusCode = HttpStatusCode.Created,
                //};
                return null;
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
