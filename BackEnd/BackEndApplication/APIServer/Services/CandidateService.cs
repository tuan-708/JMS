using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using X.PagedList;

namespace APIServer.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICurriculumVitaeRepository _context;
        private readonly ICVApplyRepository _CVApplyContext;
        private readonly IJobRepository _JobContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICurriculumVitaeRepository context, ICVApplyRepository CVApplyContext, IMapper mapper, IConfiguration configuration, ICandidateRepository candidateRepository, IJobRepository JobContext)
        {
            _context = context;
            _CVApplyContext = CVApplyContext;
            _mapper = mapper;
            _configuration = configuration;
            _candidateRepository = candidateRepository;
            _JobContext = JobContext;
        }
        public int Create(Candidate data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Candidate data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Candidate data)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Candidate> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Candidate data)
        {
            throw new NotImplementedException();
        }
        public CurriculumVitae? GetCVById(int id)
        {
            var rs = _context.GetById(id);
            if (rs == null)
                throw new Exception("CV not exist");
            return rs;
        }

        public List<CurriculumVitae> getAllCVByCandidateId(int candidateId)
        {
            var rs = _context.GetAllById(candidateId);
            if (rs == null)
                throw new Exception("CV not exist");
            return rs;
        }

        public async Task<int> ApplyJob(int candidateId, int CVid, int jobDescriptionId)
        {
            
            try
            {
                var CVList = _mapper.Map<List<CurriculumVitaeDTO>>(getAllCVByCandidateId(candidateId));
                var CVAppliedByCVIdList = _mapper.Map<List<CVApplyDTO>>(_CVApplyContext.GetByCVIdAndJobDescriptionId(CVid, jobDescriptionId));
                CurriculumVitae? cv = GetCVById(CVid);
                var curriculumVitae = _mapper.Map<CurriculumVitaeDTO>(cv);
                JobDescription jobDescription = _JobContext.GetById(jobDescriptionId);
                if (cv != null)
                        {
                    if (CVList.Any(cv => cv.Id == curriculumVitae.Id))
                    {
                        CVApply CVApplied = new CVApply();

                        if (CVAppliedByCVIdList.Any(x => x.CurriculumVitaeId == curriculumVitae.Id && x.LastUpdateDate == cv.LastUpdateDate && x.IsAutoMatched == true && x.IsReject == false))
                        {
                            CVApplied = _CVApplyContext.GetByCVIdAndLastUpdateDate(curriculumVitae.Id, cv.LastUpdateDate);
                            CVApplied.IsApplied = true;
                            CVApplied.IsReject = false;
                            return _CVApplyContext.Update(CVApplied);
                        }
                        else
                        {
                            CVApplied.JobDescriptionId = jobDescriptionId;
                            CVApplied.CandidateId = candidateId;
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
                            CVApplied.CreatedDate = Convert.ToDateTime(curriculumVitae.CreatedDateDisplay);
                            CVApplied.LastUpdateDate = Convert.ToDateTime(curriculumVitae.LastUpdateDateDisplay);
                            CVApplied.CurriculumVitaeId = curriculumVitae.Id;
                            CVApplied.IsAutoMatched = false;
                            CVApplied.IsApplied = true;
                            CVApplied.IsReject = false;
                            string JSONrs = await GPT_PROMPT.GetResult(GPT_PROMPT.PromptForRecruiter(jobDescription, cv));
                            CVApplied.JSONMatching = JSONrs;
                            CVApplied.PercentMatching = Validation.checkPercentMatchingFromJSON(JSONrs);
                            return _CVApplyContext.Create(CVApplied);
                        }

                    }
                    else throw new Exception("Your CV not exist");
                }
                else throw new Exception("Your CV not exist");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }

        public List<CVApply> GetCVAppliedHistory(int candaidateId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVApply> cVApplies = _CVApplyContext.GetAllByCandidateIdAndFromDataAndToDate(candaidateId, fromDate, toDate);
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

        public CVApply GetCVAppliedDetail(int candidateId, int CVAppliedId)
        {
            CVApply cVApplied = _CVApplyContext.GetByCandidateIdAndCVAppliedId(candidateId, CVAppliedId);
            return cVApplied;
        }

        public string LoginCandidate(string? username, string? password)
        {
            if (Validation.checkStringIsEmpty(username, password))
            {
                throw new ArgumentNullException("Data not valid");
            }
            var can = _candidateRepository.LoginCandidate(username, password);
            if (can == null)
            {
                throw new Exception("Not found");
            }
            return generateToken(can);
        }

        public string generateToken(Candidate candidate)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("UserId", candidate.Id.ToString()),
                        new Claim("DisplayName", candidate.FullName),
                        new Claim("UserName", candidate.UserName),
                        new Claim("Email", candidate.Email),
                        new Claim(ClaimTypes.Role, GlobalStrings.ROLE_CANDIDATE),
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
    }
}
