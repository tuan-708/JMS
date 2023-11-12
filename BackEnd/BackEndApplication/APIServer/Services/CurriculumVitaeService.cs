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
        private readonly ICurriculumVitaeRepository _context;
        private readonly ICVMatchingRepository _CVApplyContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CurriculumVitaeService(ICurriculumVitaeRepository context, ICVMatchingRepository CVApplyContext, IMapper mapper, IConfiguration configuration)
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

    }
}
