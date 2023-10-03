using APIServer.Common;
using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APIServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(User data)
        {
            data.createdDate = DateTime.Now;
            data.lastUpdate = DateTime.Now;
            data.isActive = true;
            data.isDelete = false;
            data.role = Role.User;
            data.createdBy = null;
            return _userRepository.Create(data);
        }

        public int CreateAdminAccount(User account, int? adminId)
        {
            if (adminId == null || adminId == 0)
                throw new ArgumentNullException("need admin permission");
            account.createdDate = DateTime.Now;
            account.lastUpdate = DateTime.Now;
            account.isActive = true;
            account.isDelete = false;
            account.role = Role.Admin;
            account.createdBy = adminId;
            return _userRepository.Create(account);
        }

        public int Delete(User data)
        {
            throw new NotImplementedException();
        }

        public string generateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string generateToken(User? userInfo, IConfiguration _configuration)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("UserId", userInfo.id.ToString()),
                        new Claim("DisplayName", userInfo.fullName),
                        new Claim("UserName", userInfo.userName),
                        new Claim("Email", userInfo.email),
                        new Claim(ClaimTypes.Role, userInfo.role.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(double.Parse(_configuration["Jwt:expiredMins"])),
                //expires: DateTime.Now.AddSeconds(20),
                signingCredentials: signIn);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

        public List<User> getAll()
        {
            throw new NotImplementedException();
        }

        public User getById(int? id)
        {
            if (id == null) throw new ArgumentNullException("error");
            var rs = _userRepository.GetById((int)id);
            if (rs == null)
                throw new NullReferenceException("error");
            return rs;
        }

        public User Login(string? username, string? password)
        {
            if (Validation.checkStringIsEmpty(username, password))
            {
                throw new ArgumentNullException("username or password empty");
            }
            var user = _userRepository.Login(username, password);
            if (user == null)
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            return user;
        }

        public TokenModel regenerateToken(TokenModel? expiredToken, IConfiguration _configuration)
        {
            if(expiredToken == null || 
                Validation.checkStringIsEmpty(expiredToken.accessToken, expiredToken.refreshToken))
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            var username = GetUserFromExpiredToken(expiredToken.accessToken);
            var user = _userRepository.findByUserName(username);
            if (user == null || 
                user.RefreshToken != expiredToken.refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            var newToken = generateToken(user, _configuration);
            var newRefresh = generateRefreshToken();
            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(15);
            return new TokenModel
            {
                accessToken = newToken,
                refreshToken = newRefresh,
            };
        }

        public void revokeToken(TokenModel? token)
        {
            if (token == null ||
                Validation.checkStringIsEmpty(token.accessToken, token.refreshToken))
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            var username = GetUserFromExpiredToken(token.accessToken);
            var user = _userRepository.findByUserName(username);
            if (user == null)
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            user.RefreshToken = null;
            _userRepository.Update(user);
        }

        public int Update(User data)
        {
            return _userRepository.Update(data);
        }

        private string GetUserFromExpiredToken(string token)
        {
            try
            {
                token = token.Trim();
                if (token == null)
                    throw new NullReferenceException(GlobalStrings.LOGIN_ERROR);
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string user = jwt.Claims.First(c => c.Type == "UserName").Value;
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
