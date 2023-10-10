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
        private readonly ICurriculumVitaeService _curriculumVitaeService;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public RecuirterController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration)
        {
            _jobService = jobService;
            _mapper = mapper;
            _config = configuration;
            _curriculumVitaeService = curriculumVitaeService;
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
                string prompt = @"tóm tắt thông tin dưới đây dưới dạng JSON object, với tên property chỉ bao gồm: jobDescription, jobRequirment,  address 
                    (Không thểm thắt, nếu property nào không có dữ liệu hãy để giá trị null) nội dung là nội dung trong thông tin, yêu cầu chính xác, ngắn gọn, không dài dòng, 
                    và tất cả đều là text nếu có xuống dòng hãy gộp đến khi thông tin còn 1 dòng và bỏ các dấu hiệu của dòng đó thay bằng dấu phẩy, không được chứa thêm 
                    property nhỏ bên trong, tối đa và không được vượt quá 1500 chữ cái cho json object, chỉ yêu cầu đáp án
                    không cần phải giải thích hoặc có bất kì kí tự nào khác ngoài json object đã yêu cầu, nếu không đáp ứng được phải làm lại:";
                var job = _mapper.Map<JobPost>(jobDTO);
                string response = _jobService.GetResult(prompt + " jobDescription:" + job.JobDescription + ". jobRequirment:" + job.JobRequirement + ". address:" + job.Address, _config);
                job.Summary = response;
                _jobService.CreateNewPost(job, jobDTO.UserId);
                return new BaseResponseBody<string>
                {
                    data = job.Summary,
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

        [HttpGet("matching-job")]
        public async Task<BaseResponseBody<List<CurriculumVitaeDTO>>> MatchingJob(int id)
        {
            int delayBetweenRequestsMs = 4000;
            try
            {
                JobPost? job = _jobService.GetById(id);
                List<CurriculumVitae> curriculumVitaes = _curriculumVitaeService.getAll();
                List<CurriculumVitae> recommentedCurriculumVitaes = new List<CurriculumVitae>();
                if(job != null)
                {
                    foreach (CurriculumVitae curriculumVitae in curriculumVitaes)
                    {
                        string prompt = @"Có 1 công việc của nhà tuyển dụng gồm 3 properties là jobDescription(Mô tả công việc), jobRequirement(Yêu cầu công việc) và address(địa chỉ làm việc) như sau: " +
                        "jobDescription: " + job.JobDescription + ", jobRequirement: " + job.JobRequirement + ", address: " + job.Address + ". Và có 1 CV của người ứng" +
                        "bao gồm 4 properties là CVId(Id CV), jobExperience(kinh nghiệm làm việc), education(học vấn) và skills(các kĩ năng) như sau: " +
                        "CVId: " + curriculumVitae.Id + ", jobExperience: " + curriculumVitae.JobExperience + ", education:" + curriculumVitae.Education + ", skills: " + curriculumVitae.Skills;

                        prompt += ". Người ứng tuyển và yêu cầu của nhà tuyển dụng có đáp ứng cho nhau về mặt công việc cũng như chuyên ngành hay không , chỉ trả lời " +
                        "True or False , nếu True thì trả về thêm số CVId với format là True.CVId = ___";
                        string response = _jobService.GetResult(prompt, _config);
                        if (response.Contains("true"))
                        {
                            CurriculumVitae? recommentedCurriculumVitae = _curriculumVitaeService.GetById(curriculumVitae.Id);
                            if (recommentedCurriculumVitae != null)
                            {
                                recommentedCurriculumVitaes.Add(recommentedCurriculumVitae);
                            }
                        }
                            await Task.Delay(delayBetweenRequestsMs);
                    }
                }
                var rs = _mapper.Map<List<CurriculumVitaeDTO>>(recommentedCurriculumVitaes);
                return new BaseResponseBody<List<CurriculumVitaeDTO>>
                {
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.Created,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<List<CurriculumVitaeDTO>>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
