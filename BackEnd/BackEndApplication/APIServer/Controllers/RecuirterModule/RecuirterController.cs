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

        public RecuirterController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
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
        public BaseResponseBody<string> createNewPost(JobDTO jobDTO, int userId)
        {
            try
            {
                var job = _mapper.Map<JobPost>(jobDTO);
                _jobService.CreateNewPost(job, jobDTO.UserId);
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

        [HttpPost]
        [Route("get-answer-from-chatpgt")]
        public async Task<IActionResult> GetResult(string prompt)
        {
            try
            {
                string response = await _jobService.GetResult(prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
