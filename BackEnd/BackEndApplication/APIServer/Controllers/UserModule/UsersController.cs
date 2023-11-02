using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRecuirterService _userService;
        private readonly IMapper _mapper;

        public UsersController(IRecuirterService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("View/{id}")]
        //[Authorize(Roles = $"{GlobalStrings.ROLE_ADMIN}")]
        public BaseResponseBody<RecuirterDTO> getById(int id)
        {
            try
            {
                var a = _userService.getById(id);
                var rs = _mapper.Map<RecuirterDTO>(_userService.getById(id));
                return new BaseResponseBody<RecuirterDTO>
                {
                    statusCode = HttpStatusCode.OK,
                    data = rs,
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<RecuirterDTO>
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.EMPTY,
                };
            }
        }

        [HttpPost]
        [Route("create-candidate")]
        public BaseResponseBody<string> createCandidateAccount(UserCreatingDTO? userDto)
        {
            try
            {
                var user = _mapper.Map<Recuirter>(userDto);
                _userService.CreateRecuirterAccount(user);
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.Created,
                    message = GlobalStrings.SUCCESSFULLY_SAVED
                };
            }
            catch(Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.BadRequest,
                    message = ex.Message
                };
            }
        }
    }
}
