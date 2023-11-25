using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IConfiguration _config;

        public RegistersController(IConfiguration configuration, IRegisterService registerService)
        {
            _config = configuration;
            _registerService = registerService;
        }

        [HttpPost]
        [Route("register-for-candidate")]
        public BaseResponseBody<string> CreateCandidateAccount(string email, string fullName, string username, string password, string confirmPassword)
        {
            try
            {
                string registerMess = _registerService.RegisterForCandidate(email,fullName,username,password,confirmPassword);
                return new BaseResponseBody<string>
                {
                    data = registerMess,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch(Exception ex) 
            {
                return new BaseResponseBody<string>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("register-for-recuirter")]
        public BaseResponseBody<string> CreateRecuirterAccount(string email, string fullName, string username, string password, string confirmPassword)
        {
            try
            {
                string registerMess = _registerService.RegisterForRecruiter(email, fullName, username, password, confirmPassword);
                return new BaseResponseBody<string>
                {
                    data = registerMess,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
