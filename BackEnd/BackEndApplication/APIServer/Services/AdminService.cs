﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIServer.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AdminService(IAdminRepository adminContext, IMapper mapper, IConfiguration configuration)
        {
            _adminContext = adminContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(Admin data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(Admin data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Admin data)
        {
            throw new NotImplementedException();
        }

        public List<Admin> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Admin> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _adminContext.GetAllCandidates();
        }

        public List<Company> GetAllCompanies()
        {
            return _adminContext.GetAllCompanies();
        }

        public List<CurriculumVitae> GetAllCVsByCandidateId(int candidateId)
        {
            if (candidateId < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetAllCVsByCandidateId(candidateId);
        }

        public List<JobDescription> GetAllJobsByRecruiterId(int recruiterId)
        {
            if (recruiterId < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetAllJobsByRecruiterId(recruiterId);
        }

        public List<Recuirter> GetAllRecruiters()
        {
            return _adminContext.GetAllRecruiters();
        }

        public Admin? GetById(int id)
        {
            return _adminContext.GetById(id);
        }

        public Candidate GetCandidateById(int id)
        {
            if (id < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetCandidateById(id);
        }

        public Company GetCompanyById(int id)
        {
            if (id < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetCompanyById(id);
        }

        public CurriculumVitae GetCVById(int id)
        {
            if (id < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetCVById(id);
        }

        public JobDescription GetJDById(int id)
        {
            if (id < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetJDById(id);
        }

        public Recuirter GetRecruiterById(int id)
        {
            if (id < 1)
                throw new Exception("Data not valid");
            return _adminContext.GetRecruiterById(id);
        }

        public int Update(Admin data)
        {
            throw new NotImplementedException();
        }

        public int UpdateActiveStatus(int? recruiterId, int? candidateId)
        {
            if(recruiterId == null || candidateId == null)
                throw new ArgumentNullException("Input not valid");
            if (recruiterId < 1 || candidateId < 1)
                throw new ArgumentNullException("Input not valid");
            return _adminContext.UpdateActiveStatus(recruiterId, candidateId);
        }

        public string generateToken(Admin? admin)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("UserId", admin.Id.ToString()),
                        new Claim("DisplayName", admin.FullName),
                        new Claim("UserName", admin.UserName),
                        new Claim(ClaimTypes.Role, GlobalStrings.ROLE_ADMIN),
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

        public Admin Login(string? username, string? password)
        {
            if (Validation.checkStringIsEmpty(username, password))
            {
                throw new ArgumentNullException("username or password empty");
            }
            var user = _adminContext.Login(username, password);
            if (user == null)
                throw new SecurityTokenException(GlobalStrings.LOGIN_ERROR);
            return user;
        }

        public AdminDTO getAdminInformationByToken(string? token)
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
                var username = jsonToken.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
                var can = _adminContext.GetById((int)Validation.ConvertInt(canId));
                if (can.UserName != username)
                    throw new Exception("token not valid");
                var rs = _mapper.Map<AdminDTO>(can);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
