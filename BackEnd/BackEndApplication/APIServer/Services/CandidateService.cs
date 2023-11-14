﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using X.PagedList;

namespace APIServer.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICurriculumVitaeRepository _context;
        private readonly ICVMatchingRepository _CVMatchingRepository;
        private readonly IJobRepository _JobContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICurriculumVitaeRepository context, ICVMatchingRepository CVMatchingRepository, IMapper mapper, IConfiguration configuration, ICandidateRepository candidateRepository, IJobRepository JobContext)
        {
            _context = context;
            _CVMatchingRepository = CVMatchingRepository;
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
                var CVAppliedByCVIdList = _mapper.Map<List<CVMatchingDTO>>(_CVMatchingRepository.GetByCVIdAndJobDescriptionId(CVid, jobDescriptionId));
                CurriculumVitae? cv = GetCVById(CVid);
                var curriculumVitae = _mapper.Map<CurriculumVitaeDTO>(cv);
                JobDescription jobDescription = _JobContext.GetById(jobDescriptionId);
                if (cv != null)
                {
                    if (CVList.Any(cv => cv.Id == curriculumVitae.Id))
                    {
                        CVMatching CVApplied = new CVMatching();

                        if (CVAppliedByCVIdList.Any(x => x.CurriculumVitaeId == curriculumVitae.Id && x.LastUpdateDate == cv.LastUpdateDate && x.IsMatched == true && x.IsApplied == false && x.IsReject == false))
                        {
                            CVApplied = _CVMatchingRepository.GetByCVIdAndLastUpdateDate(curriculumVitae.Id, cv.LastUpdateDate);
                            CVApplied.IsApplied = true;
                            CVApplied.IsReject = false;
                            return _CVMatchingRepository.Update(CVApplied);
                        }
                        if (CVAppliedByCVIdList.Any(x => x.CandidateId == candidateId && x.JobDescriptionId == jobDescriptionId && x.IsApplied == true && x.IsReject == false))
                        {
                            return -1;
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
                            CVApplied.CreatedDate = cv.CreatedDate;
                            CVApplied.LastUpdateDate = cv.LastUpdateDate;
                            CVApplied.CurriculumVitaeId = curriculumVitae.Id;
                            CVApplied.Theme = curriculumVitae.Theme;
                            CVApplied.LevelId = cv.LevelId;
                            CVApplied.Font = curriculumVitae.Font;
                            CVApplied.IsMatched = false;
                            CVApplied.IsApplied = true;
                            CVApplied.IsSelected = false;
                            CVApplied.IsReject = false;
                            string JSONrs = await GPT_PROMPT.GetResult(GPT_PROMPT.PromptForRecruiter(jobDescription, cv));
                            CVApplied.JSONMatching = JSONrs;
                            CVApplied.PercentMatching = Validation.checkPercentMatchingFromJSON(JSONrs);
                            return _CVMatchingRepository.Create(CVApplied);
                        }

                    }
                    else throw new Exception("Your CV not exist");
                }
                else throw new Exception("Your CV not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }

        public List<CVMatching> GetCVAppliedHistory(int candaidateId, DateTime? fromDate, DateTime? toDate)
        {
            List<CVMatching> cVApplies = _CVMatchingRepository.GetAllByCandidateIdAndFromDataAndToDate(candaidateId, fromDate, toDate);
            return cVApplies;
        }

        public PagingResponseBody<List<CVMatchingDTO>> GetCVAppliedHistoryPaging(int? page, List<CVMatchingDTO> listData)
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

        public CVMatching GetCVAppliedDetail(int candidateId, int CVAppliedId)
        {
            CVMatching cVApplied = _CVMatchingRepository.GetByCandidateIdAndCVAppliedId(candidateId, CVAppliedId);
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

        public List<CVMatching> GetCVApplied(int candaidateId)
        {
            List<CVMatching> cVApplied = _CVMatchingRepository.GetAllByIsApplied(candaidateId);
            return cVApplied;
        }

        public CandidateDTO getCandidateInformationByToken(string? token)
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
                var can = _candidateRepository.GetById((int) Validation.ConvertInt(canId));
                if (can.Email != email)
                    throw new Exception("token not valid");
                var rs = _mapper.Map<CandidateDTO>(can);
                rs.Password = null;
                return rs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
