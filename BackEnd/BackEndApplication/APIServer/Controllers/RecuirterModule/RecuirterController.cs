using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
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
        public BaseResponseBody<List<JobDTO>> getAllPostJob()
        {
            var rs = _mapper.Map<List<JobDTO>>(_jobService.getAll());
            return new BaseResponseBody<List<JobDTO>>
            {
                data = rs,
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
            };
        }

        [HttpPost]
        [Route("new-post")]
        public BaseResponseBody<string> createNewPost(JobDTO jobDTO)
        {
            try
            {
                var job = _mapper.Map<JobPost>(jobDTO);
                _jobService.Create(job);
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
