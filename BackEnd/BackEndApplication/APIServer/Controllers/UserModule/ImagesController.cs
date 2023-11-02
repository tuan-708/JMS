using APIServer.Common;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APIServer.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost]
        [Route("update-img-candidate/{id}")]
        public BaseResponseBody<int> UploadImage(int id, [FromForm] IFormFile file)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = imageService.updateImageCandidate(id, file),
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                    statusCode = HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseBody<int>
                {
                    message = ex.Message,
                    statusCode = HttpStatusCode.BadRequest
                };
            }
        }
    }
}
