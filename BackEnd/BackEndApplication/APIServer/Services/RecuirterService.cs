using APIServer.Common;
using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using X.PagedList;

namespace APIServer.Services
{
    public class RecuirterService : IRecuirterService
    {
        private readonly IRecuirterRepository _recRepository;
        private readonly IConfiguration _configuration;
        private readonly ICVApplyRepository _cVApplyRepository;

        public RecuirterService(IRecuirterRepository userRepository, IConfiguration configuration, ICVApplyRepository cVApplyRepository)
        {
            _recRepository = userRepository;
            _configuration = configuration;
            _cVApplyRepository = cVApplyRepository;
        }

        public int Create(Recuirter data)
        {
            throw new NotImplementedException();
        }

        public int CreateRecuirterAccount(Recuirter? account)
        {
            if (account == null)
                throw new ArgumentNullException("account not exist");
            if (Validation.checkStringIsEmpty(
                account.FullName, account.UserName,
                account.Password, account.Email))
            {
                throw new ArgumentNullException("account not completed yet");
            }
            if (!checkEmail(account.Email))
            {
                throw new ArgumentNullException("Email not accepted");
            }
            if (_recRepository.checkExistUserNameEmail(account.UserName, account.Email))
            {
                throw new Exception("Username or email already in use");
            }
            var age = Validation.CalculateAge(account.DOB);
            if (account.DOB >= DateTime.Now || age < 18 || age > 100)
            {
                throw new Exception("Date of birth is not accepted");
            }
            account.CreatedDate = DateTime.Now;
            account.LastUpdate = DateTime.Now;
            account.IsDelete = false;
            account.IsActive = true;
            account.CreatedBy = null;
            //account.role = Role.User;
            return _recRepository.Create(account);
        }

        public int Delete(Recuirter data)
        {
            throw new NotImplementedException();
        }

        public string generateToken(Recuirter? recuirter)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("UserId", recuirter.Id.ToString()),
                        new Claim("DisplayName", recuirter.FullName),
                        new Claim("UserName", recuirter.UserName),
                        new Claim("Email", recuirter.Email),
                        new Claim(ClaimTypes.Role, GlobalStrings.ROLE_RECUIRTER),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:expiredMins"])),
                //expires: DateTime.Now.AddSeconds(20),
                signingCredentials: signIn);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

        public List<Recuirter> getAll()
        {
            return _recRepository.GetAll();
        }

        public Recuirter getById(int? id)
        {
            if (id == null) throw new ArgumentNullException("error");
            var rs = _recRepository.GetById((int)id);
            if (rs == null)
                throw new NullReferenceException("error");
            return rs;
        }

        public Recuirter Login(string? username, string? password)
        {
            if (Validation.checkStringIsEmpty(username, password))
            {
                throw new ArgumentNullException("username or password empty");
            }
            var user = _recRepository.Login(username, password);
            if (user == null)
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            return user;
        }

        public int Update(Recuirter data)
        {
            return _recRepository.Update(data);
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

        public List<Recuirter> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Recuirter data, int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetResult(string prompt)
        {
            throw new NotImplementedException();
        }

        public List<CVApply> GetCVAppliedHistory(int recruiterId, int? jobDescription, DateTime? fromDate, DateTime? toDate)
        {
            List<CVApply> cVApplies = _cVApplyRepository.GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(recruiterId, jobDescription, fromDate, toDate);
            return cVApplies;
        }

        public PagingResponseBody<List<CVApplyDTO>> GetCVAppliedHistoryPaging(int? page, List<CVApplyDTO> listData)
        {
            if (!listData.Any())
            {
                return new PagingResponseBody<List<CVApplyDTO>>
                {
                    currentPage = 0,
                    message = GlobalStrings.SUCCESSFULLY,
                    ObjectLength = 0,
                    statusCode = System.Net.HttpStatusCode.OK,
                    TotalPage = 0,
                };
            }
            var numberInOnePage = int.Parse(_configuration["PageSize"]);
            var k = listData.Count;
            var totalPage = (int)Math.Ceiling((decimal)k / numberInOnePage);
            page = page <= 0 || page == null ? 1 : page;
            page = page > totalPage ? totalPage : page;
            var data = listData.ToPagedList((int)page, numberInOnePage).ToList();
            return new PagingResponseBody<List<CVApplyDTO>>
            {
                currentPage = (int)page,
                message = GlobalStrings.SUCCESSFULLY,
                data = data,
                ObjectLength = k,
                statusCode = System.Net.HttpStatusCode.OK,
                TotalPage = totalPage,
            };
        }

        public CVApply GetCVAppliedDetail(int recuiterId, int CVAppliedId)
        {
            CVApply cVApply = _cVApplyRepository.GetByRecruiterIdAndCVAppliedId(recuiterId, CVAppliedId);
            return cVApply;
        }
    }
}
