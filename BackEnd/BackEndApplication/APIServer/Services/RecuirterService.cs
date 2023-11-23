using APIServer.Common;
using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using APIServer.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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
        private readonly ICVMatchingRepository _cVMatchingRepository;
        private readonly ICurriculumVitaeRepository _cVRepository;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobContext;

        public RecuirterService(IRecuirterRepository userRepository, IConfiguration configuration, ICVMatchingRepository cVMatchingRepository, ICurriculumVitaeRepository cVRepository, IMapper mapper, IJobRepository jobContext)
        {
            _recRepository = userRepository;
            _configuration = configuration;
            _cVMatchingRepository = cVMatchingRepository;
            _cVRepository = cVRepository;
            _mapper = mapper;
            _jobContext = jobContext;
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

        public List<CVMatching> GetCVAppliedHistory(int recruiterId, int? jobDescription, DateTime? fromDate, DateTime? toDate)
        {
            List<CVMatching> cVApplies = _cVMatchingRepository.GetAllByRecruiterIdAndJobDescriptionIdAndFromDataAndToDate(recruiterId, jobDescription, fromDate, toDate);
            return cVApplies;
        }

        public PagingResponseBody<List<CVMatchingDTO>> GetCVPaging(int? page, List<CVMatchingDTO> listData)
        {
            if (!listData.Any())
            {
                return new PagingResponseBody<List<CVMatchingDTO>>
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
            return new PagingResponseBody<List<CVMatchingDTO>>
            {
                currentPage = (int)page,
                message = GlobalStrings.SUCCESSFULLY,
                data = data,
                ObjectLength = k,
                statusCode = System.Net.HttpStatusCode.OK,
                TotalPage = totalPage,
            };
        }

        public CVMatching GetCVMatchingDetail(int recruiterId, int jobDescriptionId, int CVMatchingId)
        {
            CVMatching cVApply = _cVMatchingRepository.GetByRecruiterIdAndCVAppliedId(recruiterId, jobDescriptionId, CVMatchingId);
            return cVApply;
        }

        public async Task<List<CVMatching>> GetCVFromMatchingJD(int recruiterId, int jobDescriptionId, int matchingNumberRequirement)
        {
            try
            {
                using (var context = new JMSDBContext())
                {
                    JobDescription? jd1 = context.JobDescriptions.FirstOrDefault(x => x.JobId == jobDescriptionId);
                    if(jd1 != null)
                        jd1.MatchingNumberRequirement = matchingNumberRequirement;
                    context.SaveChanges();
                }
                var JDList = _jobContext.getAllByRecuirterId(recruiterId);
                List<CVMatching> matchedList = new List<CVMatching>();
                JobDescription jd = _jobContext.GetById(jobDescriptionId);
                if (JDList.Any(x => x.JobId == jd.JobId))
                {
                    if (jd != null)
                    {
                        List<CurriculumVitae> curriculumVitaes = _cVRepository.GetAllByCategoryId(jd.CategoryId);
                        for (int i = 0; i < curriculumVitaes.Count; i++)
                        {
                            CurriculumVitae cv = _cVRepository.GetById(curriculumVitaes[i].Id);
                            CVMatching cvAfterMatching = await MatchingCV(cv.Id, jobDescriptionId, cv, jd);
                            if (cvAfterMatching != null)
                            {
                                matchedList.Add(cvAfterMatching);
                            }

                        }
                        matchedList = matchedList.OrderByDescending(cv => cv.PercentMatching).ToList();
                        for (int i = 0; i < matchedList.Count; i++)
                        {
                            using (var context = new JMSDBContext())
                            {
                                matchedList[i].IsMatched = true;
                                context.CVMatchings.Add(matchedList[i]);
                                context.SaveChanges();
                            }
                        }
                    }
                    return matchedList;
                }
                return matchedList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<CVMatching> MatchingCV(int CVid, int jobDescriptionId, CurriculumVitae cv, JobDescription jd)
        {
            using (var context = new JMSDBContext())
            {
                List<CVMatching> cVApplyList = context.CVMatchings.Include(c => c.Candidate).Include(p => p.Level)
                .Include(j => j.JobDescription).ThenInclude(c => c.Company)
                .Include(j => j.JobDescription).ThenInclude(c => c.Category)
                .Include(j => j.JobDescription).ThenInclude(c => c.Recuirter)
                .Include(j => j.JobDescription).ThenInclude(e => e.EmploymentType).Where(x => x.CurriculumVitaeId == CVid && x.JobDescriptionId == jobDescriptionId && x.IsReject == false).ToList();
                var CVAppliedByCVIdList = _mapper.Map<List<CVMatchingDTO>>(cVApplyList);
                if (cv != null && jd != null)
                {
                    var curriculumVitae = _mapper.Map<CurriculumVitaeDTO>(cv);
                    CVMatching CVApplied = new CVMatching();

                    if (cVApplyList.Any(x => x.CurriculumVitaeId == curriculumVitae.Id && x.LastUpdateDate == cv.LastUpdateDate && x.IsApplied == true && x.IsMatched == false && x.IsReject == false))
                    {
                        CVApplied = context.CVMatchings.FirstOrDefault(x => x.CurriculumVitaeId == curriculumVitae.Id && x.LastUpdateDate == cv.LastUpdateDate && x.IsApplied == true && x.IsMatched == false && x.IsReject == false);
                        string JSONrs1 = await GPT_PROMPT.GetResult(GPT_PROMPT.PromptForRecruiter(jd, cv));
                        CVApplied.JSONMatching = JSONrs1;
                        CVApplied.PercentMatching = Validation.checkPercentMatchingFromJSON(JSONrs1);
                        CVApplied.IsMatched = true;
                        context.SaveChanges();
                        await Task.Delay(12000);
                        return null;
                    }
                    if (cVApplyList.Any(x => x.CurriculumVitaeId == curriculumVitae.Id && x.LastUpdateDate == cv.LastUpdateDate && x.IsMatched == true && x.IsReject == false))
                    {
                        return null;
                    }
                    CVApplied.JobDescriptionId = jobDescriptionId;
                    CVApplied.CandidateId = curriculumVitae.CandidateId;
                    CVApplied.CareerGoal = curriculumVitae.CareerGoal;
                    CVApplied.Phone = curriculumVitae.Phone;
                    CVApplied.DisplayName = curriculumVitae.DisplayName;
                    CVApplied.GenderId = curriculumVitae.GenderId;
                    CVApplied.CategoryName = curriculumVitae.CategoryId.ToString();
                    CVApplied.DisplayEmail = curriculumVitae.DisplayEmail;
                    CVApplied.DOB = Convert.ToDateTime(curriculumVitae.DOB);
                    CVApplied.Address = curriculumVitae.Address;
                    CVApplied.Education = JsonConvert.SerializeObject(curriculumVitae.Educations);
                    CVApplied.JobExperience = JsonConvert.SerializeObject(curriculumVitae.JobExperiences);
                    CVApplied.Skill = JsonConvert.SerializeObject(curriculumVitae.Skills);
                    CVApplied.Project = JsonConvert.SerializeObject(curriculumVitae.Projects);
                    CVApplied.Certificate = JsonConvert.SerializeObject(curriculumVitae.Certificates);
                    CVApplied.Award = JsonConvert.SerializeObject(curriculumVitae.Awards);
                    CVApplied.ApplyDate = DateTime.Now;
                    CVApplied.CreatedDate = cv.CreatedDate;
                    CVApplied.LastUpdateDate = cv.LastUpdateDate;
                    CVApplied.Theme = curriculumVitae.Theme;
                    CVApplied.LevelId = cv.LevelId;
                    CVApplied.Font = curriculumVitae.Font;
                    string JSONrs = await GPT_PROMPT.GetResult(GPT_PROMPT.PromptForRecruiter(jd, cv));
                    CVApplied.JSONMatching = JSONrs;
                    CVApplied.PercentMatching = Validation.checkPercentMatchingFromJSON(JSONrs);
                    CVApplied.CurriculumVitaeId = curriculumVitae.Id;
                    CVApplied.IsMatched = false;
                    CVApplied.IsApplied = false;
                    CVApplied.IsSelected = false;
                    CVApplied.IsReject = false;
                    await Task.Delay(12000);
                    return CVApplied;

                }
                else throw new Exception("cv or jd does not exist");
            }
        }

        public string getEstimateDate(int jobId, DateTime dateRequirment)
        {
            int second = 15;
            JobDescription jobDescriptions = _jobContext.GetById(jobId);
            if (jobDescriptions != null)
            {
                List<CurriculumVitae> curriculumVitaes = _cVRepository.GetAllByCategoryId(jobDescriptions.CategoryId);
                if (curriculumVitaes != null)
                {
                    second = second * curriculumVitaes.Count;
                    if (dateRequirment > DateTime.Now.AddSeconds(second))
                    {
                        return dateRequirment.AddSeconds(-second).ToString();

                    }
                    else
                    {
                        return $"Date Requirement have to be started at {DateTime.Now.AddSeconds(second + 60)} or later";
                    }
                }
                return "Now the system doesn't have any CV that can match with your JD. Try again later.";
            }
            return "Your JD does not exist";
        }

        public List<CVMatching> GetCVSelected(int recruiterId, int jobDescriptionId)
        {
            List<CVMatching> CVSelected = _cVMatchingRepository.GetAllByIsSelected(recruiterId, jobDescriptionId);
            return CVSelected;
        }

        public List<CVMatching> GetCVMatchedLeft(int recruiterId, int jobDescriptionId)
        {
            List<CVMatching> CVMatched = _cVMatchingRepository.GetAllByIsMatchedLeft(recruiterId, jobDescriptionId);
            using (var context = new JMSDBContext())
            {
                JobDescription? jobDescription = context.JobDescriptions.FirstOrDefault(x => x.RecuirterId == recruiterId && x.JobId == jobDescriptionId);
                if(jobDescription != null && jobDescription.MatchingNumberRequirement != null)
                {
                    return CVMatched.Skip((int)jobDescription.MatchingNumberRequirement).ToList();
                }
                return null;
            }
            
        }
        public List<CVMatching> GetCVMatchedByNumberRequirement(int recruiterId, int jobDescriptionId)
        {
            List<CVMatching> CVMatched = _cVMatchingRepository.GetAllByIsMatchedByNumberRequirement(recruiterId, jobDescriptionId);
            using (var context = new JMSDBContext())
            {
                JobDescription? jobDescription = context.JobDescriptions.FirstOrDefault(x => x.RecuirterId == recruiterId && x.JobId == jobDescriptionId);
                if (jobDescription != null && jobDescription.MatchingNumberRequirement != null)
                {
                    return CVMatched.Take((int)jobDescription.MatchingNumberRequirement).ToList();
                }
                return null;
            }
        }

        public List<CVMatching> GetCVApplied(int recruiterId, int jobDescriptionId)
        {
            List<CVMatching> CVApplied = _cVMatchingRepository.GetAllByIsApplied(recruiterId, jobDescriptionId);
            return CVApplied;
        }

        public int UpdateCVSelectedStatus(int recruiterId, int jobDescriptionId, int CVMatchingId)
        {
            return _cVMatchingRepository.UpdateSelectedStatus(recruiterId, jobDescriptionId, CVMatchingId);
        }

        public int UpdateCVRejectedStatus(int recruiterId, int jobDescriptionId, int CVMatchingId)
        {
            return _cVMatchingRepository.UpdateRejectedStatus(recruiterId, jobDescriptionId, CVMatchingId);
        }

        public RecuirterDTO getRecruiterInformationByToken(string? token)
        {
            try
            {
                if (Validation.checkStringIsEmpty(token))
                {
                    throw new Exception("token not valid");
                }
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    throw new Exception("your token not valid");
                }
                if (jsonToken.ValidTo < DateTime.UtcNow)
                    throw new Exception("token has expired");
                var canId = jsonToken.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                var email = jsonToken.Claims.FirstOrDefault(x => x.Type == "Email").Value;
                var can = _recRepository.GetById((int)Validation.ConvertInt(canId));
                if (can.Email != email)
                    throw new Exception("token not valid");
                var rs = _mapper.Map<RecuirterDTO>(can);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
