using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.CandidateModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVsController : ControllerBase
    {
        private readonly ICurriculumVitaeService cvService;
        private readonly IJobService jobService;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public CVsController(ICurriculumVitaeService cvService, IJobService jobService, IMapper mapper, IConfiguration config)
        {
            this.cvService = cvService;
            this.jobService = jobService;
            this.mapper = mapper;
            this.config = config;
        }

        [HttpGet]
        [Route("all-cv/{id}")]
        public BaseResponseBody<CurriculumVitaeDTO> getAllCVs(int id)
        {
            try
            {
                var data = cvService.GetById(id);
                var rs = mapper.Map<CurriculumVitaeDTO>(data);
                return new BaseResponseBody<CurriculumVitaeDTO>
                {
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new BaseResponseBody<CurriculumVitaeDTO>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
