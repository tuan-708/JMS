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
        public IConfiguration _configuration;
        private readonly IUserService userService;

        public TokenController(IMapper mapper, IUserService userService, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public BaseResponseBody<TokenModel> login(LoginModel loginModel)
        {
            try
            {
                var user = userService.Login(loginModel.username, loginModel.password);
                var refreshTok = userService.generateRefreshToken();
                user.RefreshToken = refreshTok;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(
                    double.Parse(_configuration["Jwt:expireRefresh"]));
                userService.Update(user);
                return new BaseResponseBody<TokenModel>
                {
                    statusCode = HttpStatusCode.OK,
                    data = new TokenModel
                    {
                        accessToken = userService.generateToken(user, _configuration),
                        refreshToken = refreshTok,
                    },
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<TokenModel>
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.LOGIN_ERROR,
                };
            }
        }

        [HttpPost]
        [Route("refresh")]
        public BaseResponseBody<TokenModel> Refresh(TokenModel tokenApiModel)
        {
            try
            {
                return new BaseResponseBody<TokenModel>
                {
                    statusCode = HttpStatusCode.OK,
                    data = userService.regenerateToken(tokenApiModel, _configuration),
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<TokenModel>
                {
                    statusCode = HttpStatusCode.Unauthorized,
                    data = null,
                    message = GlobalStrings.LOGIN_ERROR,
                };
            }
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public BaseResponseBody<string> Revoke(TokenModel? token)
        {
            try
            {
                userService.revokeToken(token);
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.SUCCESSFULLY,
                };
            }
            catch
            {
                return new BaseResponseBody<string>
                {
                    statusCode = HttpStatusCode.Unauthorized,
                    data = null,
                    message = GlobalStrings.LOGIN_ERROR,
                };
            }
        }
    }
}
