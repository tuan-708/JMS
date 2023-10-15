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
using System.Text.RegularExpressions;

namespace APIServer.Services
{
    public class UserService : IUserService
    {
        private readonly IRecuirterRepository _userRepository;

        public UserService(IRecuirterRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(Recuirter data)
        {
            throw new NotImplementedException();
        }

        public int CreateAdminAccount(Recuirter account, int? adminId)
        {
            if (adminId == null || adminId == 0)
                throw new ArgumentNullException("need admin permission");
            account.CreatedDate = DateTime.Now;
            account.LastUpdate = DateTime.Now;
            //account.isActive = true;
            //account.isDelete = false;
            //account.Role = Role.Admin;
            account.CreatedBy = adminId;
            return _userRepository.Create(account);
        }

        public int CreateCandidateAccount(Recuirter? account)
        {
            if (account == null)
                throw new ArgumentNullException("account not exist");
            //if (Validation.checkStringIsEmpty(
            //    account.fullName, account.UserName,
            //    account.Password, account.Email))
            //{
            //    throw new ArgumentNullException("account not completed yet");
            //}
            if (!checkEmail(account.Email))
            {
                throw new ArgumentNullException("Email not accepted");
            }
            if (_userRepository.checkExistUserNameEmail(account.UserName, account.Email))
            {
                throw new Exception("Username or email already in use");
            }
            var age = CalculateAge(account.DOB);
            if (account.DOB >= DateTime.Now || age < 18 || age > 100)
            {
                throw new Exception("Date of birth is not accepted");
            }
            account.CreatedDate = DateTime.Now;
            account.LastUpdate = DateTime.Now;
            //account.isDelete = false;
            //account.isActive = true;
            account.CreatedBy = null;
            //account.role = Role.User;
            account.IsMale = account.IsMale == null ? true : account.IsMale;
            return _userRepository.Create(account);
        }

        public int Delete(Recuirter data)
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

        public string generateToken(Recuirter? userInfo, IConfiguration _configuration)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        //new Claim("UserId", userInfo.id.ToString()),
                        //new Claim("DisplayName", userInfo.fullName),
                        new Claim("UserName", userInfo.UserName),
                        new Claim("Email", userInfo.Email),
                        new Claim(ClaimTypes.Role, userInfo.Role.ToString()),
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

        public List<Recuirter> getAll()
        {
            throw new NotImplementedException();
        }

        public Recuirter getById(int? id)
        {
            if (id == null) throw new ArgumentNullException("error");
            var rs = _userRepository.GetById((int)id);
            if (rs == null)
                throw new NullReferenceException("error");
            return rs;
        }

        public string GetResult(string prompt, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public Recuirter Login(string? username, string? password)
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
            if (expiredToken == null ||
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
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(
                double.Parse(_configuration["Jwt:expireRefresh"]));
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

        public int Update(Recuirter data)
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

        private bool checkEmail(string? email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, pattern);
        }

        private static int CalculateAge(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;
            if (ngayHienTai.Month < ngaySinh.Month || (ngayHienTai.Month == ngaySinh.Month && ngayHienTai.Day < ngaySinh.Day))
            {
                tuoi--;
            }
            return tuoi;
        }

        public void CreateCandidateCV(CurriculumVitae curriculumVitae)
        {
            
        }

        public List<Recuirter> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Recuirter data, int id)
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
