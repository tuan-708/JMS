using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using X.PagedList;

namespace APIServer.Services
{
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly ICurriculumVitaeRepository _context;
        private readonly ICVMatchingRepository _CVApplyContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICandidateRepository _candidateRepository;

        public CurriculumVitaeService(ICurriculumVitaeRepository context, ICVMatchingRepository CVApplyContext, IMapper mapper, IConfiguration configuration, ICandidateRepository candidateRepository)
        {
            _context = context;
            _CVApplyContext = CVApplyContext;
            _mapper = mapper;
            _configuration = configuration;
            _candidateRepository = candidateRepository;
        }

        public int Create(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(CurriculumVitae cv, int candidateId)
        {
            cv.CandidateId = candidateId;
            if (!Validation.checkStringIsEmpty(cv.Phone, cv.DisplayName, cv.DisplayEmail, cv.CVTitle) &&
                !Validation.IsPhoneNumberValid(cv.Phone))
            {
                throw new ArgumentNullException("cv not finished yet");
            }
            cv.IsActive = true;
            cv.IsDelete = false;
            cv.CreatedDate = DateTime.Now;
            cv.LastUpdateDate = DateTime.Now;
            return _context.Create(cv);
        }

        public int Delete(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public List<CurriculumVitae> getAll()
        {
            return _context.GetAll();
        }

        public List<CurriculumVitae> getAllById(int candidateId)
        {
            var rs = _context.GetAllById(candidateId);
            if (rs == null)
                throw new Exception("CV not exist");
            return rs;
        }

        public CurriculumVitae? GetById(int id)
        {
            var rs = _context.GetById(id);
            if (rs == null)
                throw new Exception("CV not exist");
            return rs;
        }

        public CurriculumVitae GetCurriculumVitaeByCandidateId(int candidateId, int CVid)
        {
            var rs = _context.GetById(CVid);
            if (rs == null)
                throw new Exception("CV not exist");
            if (rs.CandidateId != candidateId)
            {
                throw new Exception("Permission denied");
            }
            return rs;
        }

        public int Update(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public int UpdateCvByCandidateIdAndCvId(int candidateId, int cvId, CurriculumVitaeDTO cvDTO)
        {
            var can = _candidateRepository.GetById(candidateId);
            var cv = _context.GetById(cvId);
            if (can == null || cv == null || cvDTO == null)
            {
                throw new Exception("Data not valid");
            }
            if (cv.CandidateId != candidateId)
            {
                throw new Exception("Permission denied");
            }
            var cvChange = _mapper.Map<CurriculumVitae>(cvDTO);
            using (var context = new JMSDBContext())
            {
                var cvOrigin = context.CurriculumVitaes
                    .Include(x => x.Category)
                    .Include(x => x.Educations)
                    .Include(x => x.Certificates)
                    .Include(x => x.Awards)
                    .Include(x => x.Skills)
                    .Include(x => x.Projects)
                    .Include(x => x.JobExperiences)
                    .Include(x => x.Gender)
                    .Include(x => x.Level)
                    .Include(x => x.EmploymentType)
                    .First(x => x.Id == cvId);
                if (cvOrigin.Educations.Any())
                {
                    context.RemoveRange(cvOrigin.Educations);
                }
                if (cvOrigin.Certificates.Any())
                {
                    context.RemoveRange(cvOrigin.Certificates);
                }
                if (cvOrigin.Awards.Any())
                {
                    context.RemoveRange(cvOrigin.Awards);
                }
                if (cvOrigin.Skills.Any())
                {
                    context.RemoveRange(cvOrigin.Skills);
                }
                if (cvOrigin.Projects.Any())
                {
                    context.RemoveRange(cvOrigin.Projects);
                }
                if (cvOrigin.JobExperiences.Any())
                {
                    context.RemoveRange(cvOrigin.JobExperiences);
                }

                cvOrigin.CareerGoal = cvChange.CareerGoal;
                cvOrigin.EmploymentTypeId = cvChange.EmploymentTypeId;
                cvOrigin.Phone = cvChange.Phone;
                cvOrigin.DisplayName = cvChange.DisplayName;
                cvOrigin.DisplayEmail = cvChange.DisplayEmail;
                cvOrigin.Address = cvChange.Address;
                cvOrigin.DOB = cvChange.DOB;
                cvOrigin.LevelId = cvChange.LevelId;
                cvOrigin.CategoryId = cvChange.CategoryId;
                cvOrigin.CVTitle = cvChange.CVTitle;
                cvOrigin.Font = cvChange.Font;
                cvOrigin.Theme = cvChange.Theme;
                cvOrigin.GenderId = cvChange.GenderId; 

                cvOrigin.Educations = cvChange.Educations;
                cvOrigin.Certificates = cvChange.Certificates;
                cvOrigin.Awards = cvChange.Awards;
                cvOrigin.Skills = cvChange.Skills;
                cvOrigin.Projects = cvChange.Projects;
                cvOrigin.JobExperiences = cvChange.JobExperiences;

                return context.SaveChanges();
            }
        }
    }
}
