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
        public BaseResponseBody<int> UpdateImgCandidate(int id, [FromForm] IFormFile file)
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

        [HttpPost]
        [Route("update-img-recuirter/{id}")]
        public BaseResponseBody<int> UpdateImgRecuirter(int id, [FromForm] IFormFile file)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = imageService.updateImageRecuirter(id, file),
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

        [HttpPost]
        [Route("update-img-cv/{id}")]
        public BaseResponseBody<int> UpdateImgCV(int id, [FromForm] IFormFile file)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = imageService.updateImageCV(id, file),
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

        [HttpPost]
        [Route("update-img-avt-company/{recuirterId}/{companyId}")]
        public BaseResponseBody<int> UpdateImgCompanyAvt(int recuirterId, int companyId, [FromForm] IFormFile file)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = imageService.updateImageAvtCompany(companyId, recuirterId, file),
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

        [HttpPost]
        [Route("update-img-bgr-company/{recuirterId}/{companyId}")]
        public BaseResponseBody<int> UpdateImgCompanyBgr(int recuirterId, int companyId, [FromForm] IFormFile file)
        {
            try
            {
                return new BaseResponseBody<int>
                {
                    data = imageService.updateImageBgrCompany(companyId, recuirterId, file),
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
