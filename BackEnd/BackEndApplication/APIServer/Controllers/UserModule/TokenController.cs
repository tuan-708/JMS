using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;
        private readonly IRecuirterService recuirterService;
        private readonly ICandidateService candidateService;

        public TokenController(IMapper mapper, IRecuirterService userService, IConfiguration configuration, ICandidateService candidateService)
        {
            this.mapper = mapper;
            this.recuirterService = userService;
            _configuration = configuration;
            this.candidateService = candidateService;
        }

        [HttpPost]
        [Route("login-recuirter")]
        public BaseResponseBody<string> loginForRecuirter(LoginModel loginModel)
        {
            try
            {
                var user = recuirterService.Login(loginModel.username, loginModel.password);
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.OK,
                    data = recuirterService.generateToken(user),
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.LOGIN_ERROR,
                };
            }
        }

        [HttpPost]
        [Route("login-candidate")]
        public BaseResponseBody<string> loginForCandidate(LoginModel loginModel)
        {
            try
            {
                var u = loginModel.username;
                var p = loginModel.password;
                return new BaseResponseBody<string>
                {
                    data = candidateService.LoginCandidate(u, p),
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch(Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    message = GlobalStrings.LOGIN_ERROR,
                    statusCode = HttpStatusCode.Unauthorized,
                };
            }
        }

        [HttpGet]
        [Route("test-recuirter")]
        [Authorize(Roles = $"{GlobalStrings.ROLE_RECUIRTER}")]
        public IActionResult testAuthor()
        {
            return Ok(recuirterService.getAll());
        }

        [HttpGet]
        [Route("test-candidate")]
        [Authorize(Roles = $"{GlobalStrings.ROLE_CANDIDATE}")]
        public IActionResult testAuthorCan()
        {
            return Ok(recuirterService.getAll());
        }
    }
}
