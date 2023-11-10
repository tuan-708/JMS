using APIServer.Common;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;


        public EmailController(IConfiguration configuration, IEmailService emailService)
        {
            _config = configuration;
            _emailService = emailService;
        }

        [HttpPost("forgot-candidate-password")]
        public BaseResponseBody<string> ForgotCandidatePassword(string email)
        {
            try
            {
                string forgotPasswordMess = _emailService.ForgotPasswordForCandidate(email);

                return new BaseResponseBody<string>
                {
                    data = forgotPasswordMess,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    data = ex.Message,
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost("forgot-recruiter-password")]
        public BaseResponseBody<string> ForgotRecruiterPassword(string email)
        {
            try
            {
                string forgotPasswordMess = _emailService.ForgotPasswordForRecruiter(email);

                return new BaseResponseBody<string>
                {
                    data = forgotPasswordMess,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<string>
                {
                    data = ex.Message,
                    message = GlobalStrings.BAD_REQUEST,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
