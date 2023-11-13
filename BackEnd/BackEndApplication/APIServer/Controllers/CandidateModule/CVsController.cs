﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Route("all-cv/{candidateId}")]
        public PagingResponseBody<List<CurriculumVitaeDTO>> getAllCVs(int candidateId)
        {
            try
            {
                var data = cvService.getAllById(candidateId);
                var rs = mapper.Map<List<CurriculumVitaeDTO>>(data);
                return new PagingResponseBody<List<CurriculumVitaeDTO>>
                {
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = HttpStatusCode.OK,
                    ObjectLength = rs.Count,
                    TotalPage = 1,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new PagingResponseBody<List<CurriculumVitaeDTO>>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpGet]
        [Route("getCV/{candidateId}/{cvId}")]
        public BaseResponseBody<CurriculumVitaeDTO> getOneCVByCanID(int candidateId, int cvId)
        {
            try
            {
                var rs = mapper.Map<CurriculumVitaeDTO>(cvService.GetCurriculumVitaeByCandidateId(candidateId, cvId));
                return new BaseResponseBody<CurriculumVitaeDTO>
                {
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception e)
            {
                return new BaseResponseBody<CurriculumVitaeDTO>
                {
                    message = e.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("new-cv/{candidateId}")]
        public BaseResponseBody<int> createNewCV(int candidateId,
            [FromBody] CurriculumVitaeDTO cv)
        {
            try
            {
                var c = mapper.Map<CurriculumVitae>(cv);
                var rs = cvService.CreateById(c, candidateId);
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.Created,
                    data = c.Id,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                    data = -1,
                };
            }
        }

        [HttpPost]
        [Route("update-cv")]
        public BaseResponseBody<int> updateCv(int candidateId, int cvId, CurriculumVitaeDTO cvDTO)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                    data = cvService.UpdateCvByCandidateIdAndCvId(candidateId, cvId, cvDTO),
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    message = ex.InnerException.Message,
                    statusCode = HttpStatusCode.BadRequest,
                    data = -1,
                };
            }
        }
    }
}
