using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        [HttpPost]
        [Route("create-candidate")]
        public BaseResponseBody<int> CreateCandidateAccount(CandidateDTO candidate)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = -1,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch(Exception ex) 
            {
                return new BaseResponseBody<int>
                {
                    data = -1,
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        [HttpPost]
        [Route("create-recuirter")]
        public BaseResponseBody<int> CreateRecuirterAccount(RecuirterDTO recuirter)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = -1,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    data = -1,
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
