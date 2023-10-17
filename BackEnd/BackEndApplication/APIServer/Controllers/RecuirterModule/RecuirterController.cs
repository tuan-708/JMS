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
        private readonly JMSDBContext context;

        public RecuirterController(IJobService jobService, ICurriculumVitaeService curriculumVitaeService, IMapper mapper, IConfiguration configuration, JMSDBContext jMSDBContext)
        {
            _jobService = jobService;
            _mapper = mapper;
            _config = configuration;
            _curriculumVitaeService = curriculumVitaeService;
            this.context = jMSDBContext;
        }

        [HttpGet]
        [Route("get-all")]
        public PagingResponseBody<List<JobDTO>> getAllPostJob()
        {
            //var rs = _mapper.Map<List<JobDTO>>(_jobService.getAll());
            var rs = context.JobDescriptions.ToList();
            return new PagingResponseBody<List<JobDTO>>
            {
                data = _mapper.Map<List<JobDTO>>(rs),
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
                var data = _mapper.Map<JobDescription>(jobDTO);
                data.CreatedAt = DateTime.Now;
                data.ExpiredDate = DateTime.Now.AddDays(7);
                data.IsDelete = false;
                data.PositionTitles = null;
                data.EmploymentTypeId = null;
                context.JobDescriptions.Add(data);
                return new BaseResponseBody<string>
                {
                    data = context.SaveChanges() + "",
                    //data = data.ToString(),
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

        [HttpGet]
        [Route("test-prompt")]
        public async Task<IActionResult> getTest()
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, mỗi ý so sánh dưới đấy sẽ bao gồm nhiều cặp vế, mỗi cặp vế sẽ có một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy cặp vế đó trả về 1 còn không thì trả về 0 cho tất cả các cặp vế so sánh, và nếu trong một ý so sánh có một hoặc nhiều cặp vế trả về 1 thì cả ý so sánh sẽ trả về 1 và ngược lại, vui lòng chỉ trả lời bằng một mảng int kết quả với format [0, 1] mà không có bất kỳ giải thích nào.: 
- ý so sánh 1:
Vế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: ' 
Vế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Nhân viên Content – Marketing, tại công ty: Công ty Cổ phần kiến trúc và nội thất CV365, từ 02/2018 đến 05/2018, với vị trí: nhân viên tạm thời, với mô tả như sau: ' 
- ý so sánh 2:
Vế 1: 'yêu cầu giỏi java' và Vế 2: 'giỏi java' 
Vế 1: 'yêu cầu giỏi java' và Vế 2: 'giỏi đàn' 
Vế 1: 'yêu cầu giỏi java' và Vế 2: 'giỏi hát'";
            //var job = context.JobDescriptions
            //   .Include(x => x.Recuirter)
            //   .Include(x => x.PositionTitles)
            //   .Include(x => x.EmploymentType)
            //   .Include(x => x.Company)
            //   .Include(x => x.Category)
            //   .FirstOrDefault();
            //var cv = context.CurriculumVitaes
            //    .Include(x => x.JobExperiences)
            //    .Include(x => x.Skills)
            //    .Include(x => x.Educations)
            //    .Include(x => x.Projects)
            //    .Include(x => x.Certificates)
            //    .Include(x => x.Awards)
            //    .FirstOrDefault();
            //var rs = GPT_PROMPT.MATCHING_FOR_RECUITER(job, cv);
            //rs = _jobService.GetResult(rs);
            var str = await _jobService.GetResult(prompt);
            return Ok(str);
        }

        [HttpGet("test-cv")]
        public IActionResult test1()
        {
            var cv = context.CurriculumVitaes
                .Include(x => x.JobExperiences)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Projects)
                .Include(x => x.Certificates)
                .Include(x => x.Awards)
                .FirstOrDefault();
            return Ok(cv);
        }

        
    }
}
