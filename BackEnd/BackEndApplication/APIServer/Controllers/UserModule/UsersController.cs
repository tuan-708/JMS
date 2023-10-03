﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("View/{id}")]
        public BaseResponseBody<UserDTO> getById(int id)
        {
            try
            {
                var a = _userService.getById(id);
                var rs = _mapper.Map<UserDTO>(_userService.getById(id));
                return new BaseResponseBody<UserDTO>
                {
                    statusCode = HttpStatusCode.OK,
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<UserDTO>
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.EMPTY,
                };
            }
        }
    }
}
