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
        private readonly IBaseService<PositionTitleDTO> _posService;
        private readonly IBaseService<EmploymentTypeDTO> _empService;

        public RecuirterCommonController(IBaseService<CategoryDTO> catService, IBaseService<PositionTitleDTO> posService, IBaseService<EmploymentTypeDTO> empService)
        {
            _catService = catService;
            _posService = posService;
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
        [Route("all-position-title")]
        public BaseResponseBody<List<PositionTitleDTO>> getAllPositionTitle()
        {
            return new BaseResponseBody<List<PositionTitleDTO>>
            {
                message = GlobalStrings.SUCCESSFULLY,
                statusCode = HttpStatusCode.OK,
                data = _posService.getAll(),
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
