﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanysController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanysController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public PagingResponseBody<List<CompanyDTO>> getAllCompany(int? page)
        {
            try
            {
                var list = _companyService.getAll();
                return _companyService.GetListPaging(page, list);
            }
            catch (Exception ex)
            {
                return new PagingResponseBody<List<CompanyDTO>>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public BaseResponseBody<CompanyDTO> getCompanyById(int id)
        {
            try
            {
                var com = _companyService.GetById(id);
                return new BaseResponseBody<CompanyDTO>
                {
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = HttpStatusCode.BadRequest,
                    data = com,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<CompanyDTO>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpGet]
        [Route("search/{search}/{page}")]
        public PagingResponseBody<List<CompanyDTO>> getAllCompanyByName(string? search, int? page)
        {
            try
            {
                var list = _companyService.GetAllByName(search);
                return _companyService.GetListPaging(page, list);
            }
            catch (Exception ex)
            {
                return new PagingResponseBody<List<CompanyDTO>>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("create-by-recuirter/{id}")]
        public BaseResponseBody<int> createByRecuirterId(int id, CompanyDTO companyDTO)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.Created,
                    data = _companyService.CreateById(companyDTO, id),
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("update-by-recuirter/{id}")]
        public BaseResponseBody<int> updateByRecuirterId(int id, CompanyDTO companyDTO)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                    data = _companyService.UpdateByRecuirterId(companyDTO, id),
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("delete-by-recuirter/{recuirterId}/{companyId}")]
        public BaseResponseBody<int> deleteCompanyByRecuirter(int recuirterId, int companyId)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                    data = _companyService.DeleteByRecuirterId(recuirterId, companyId),
                };
            }
            catch (Exception e)
            {
                return new BaseResponseBody<int>
                {
                    message = e.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
