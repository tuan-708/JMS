using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIServer.Controllers.RecuirterModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuirterCommonController : ControllerBase
    {
        private readonly IBaseService<CategoryDTO> _catService;
        private readonly IBaseService<LevelDTO> _levelService;
        private readonly IBaseService<EmploymentTypeDTO> _empService;

        public RecuirterCommonController(IBaseService<CategoryDTO> catService, IBaseService<LevelDTO> posService, IBaseService<EmploymentTypeDTO> empService)
        {
            _catService = catService;
            _levelService = posService;
            _empService = empService;
        }

        [HttpGet]
        [Route("all-category")]
        public BaseResponseBody<List<CategoryDTO>> getAllCategory()
        {
            return new BaseResponseBody<List<CategoryDTO>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = _catService.getAll(),
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
                data = _levelService.getAll(),
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
                data = _empService.getAll(),
            };
        }
    }
}
