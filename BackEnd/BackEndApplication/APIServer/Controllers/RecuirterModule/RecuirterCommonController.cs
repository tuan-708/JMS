using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using APIServer.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuirterCommonController : ControllerBase
    {
        private readonly IRecurterCommon recCommon;

        public RecuirterCommonController(IRecurterCommon recCommon)
        {
            this.recCommon = recCommon;
        }

        [HttpGet]
        [Route("all-category")]
        public BaseResponseBody<List<CategoryDTO>> getAllCategory()
        {
            return new BaseResponseBody<List<CategoryDTO>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = recCommon.getAllCategory(),
            };
        }

        [HttpGet]
        [Route("all-level-title")]
        public BaseResponseBody<List<LevelDTO>> getAllPositionTitle()
        {
            return new BaseResponseBody<List<LevelDTO>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = recCommon.getAllLevel(),
            };
        }

        [HttpGet]
        [Route("all-employment-type")]
        public BaseResponseBody<List<EmploymentTypeDTO>> getAllEmploymentType()
        {
            return new BaseResponseBody<List<EmploymentTypeDTO>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = recCommon.allEmploymentType(),
            };
        }

        [HttpGet]
        [Route("all-gender")]
        public BaseResponseBody<List<Gender>> getAllGender()
        {
            return new BaseResponseBody<List<Gender>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = recCommon.getAllGender(),
            };
        }
    }
}
