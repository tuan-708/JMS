using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using AutoMapper;
using Newtonsoft.Json;
using X.PagedList;

namespace APIServer.Services
{
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly IBaseRepository<CurriculumVitae> _context;
        private readonly ICVApplyRepository _CVApplyContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CurriculumVitaeService(IBaseRepository<CurriculumVitae> context, ICVApplyRepository CVApplyContext, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _CVApplyContext = CVApplyContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(CurriculumVitae cv, int candidateId)
        {
            cv.CandidateId = candidateId;
            if (!Validation.checkStringIsEmpty(cv.Phone, cv.DisplayName, cv.DisplayEmail) &&
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

        public int ApplyJob(int candaidateId, int CVid, int jobDescriptionId)
        {
            var CVList = _mapper.Map<List<CurriculumVitaeDTO>>(getAllById(candaidateId));
            var curriculumVitae = _mapper.Map<CurriculumVitaeDTO>(GetById(CVid));
            if (CVList.Any(cv => cv.Id == curriculumVitae.Id))
            {
                CVApply CVApplied = new CVApply();
                CVApplied.JobDescriptionId = jobDescriptionId;
                CVApplied.CandidateId = candaidateId;
                CVApplied.CareerGoal = curriculumVitae.CareerGoal;
                CVApplied.Phone = curriculumVitae.Phone;
                CVApplied.DisplayName = curriculumVitae.DisplayName;
                CVApplied.IsMale = curriculumVitae.IsMale;
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
                CVApplied.PercentMatching = "20%";
                return _CVApplyContext.Create(CVApplied);
            }
            else throw new Exception("Your CV not exist");
        }

        public int Update(CurriculumVitae data)
        {
            throw new NotImplementedException();
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
    }
}
