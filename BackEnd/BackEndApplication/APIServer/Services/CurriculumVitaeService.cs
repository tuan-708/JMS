using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Services
{
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly IBaseRepository<CurriculumVitae> _context;

        public CurriculumVitaeService(IBaseRepository<CurriculumVitae> context)
        {
            _context = context;
        }
        public int Create(CurriculumVitae data)
        {
            if (Validation.checkStringIsEmpty(data.DisplayName, data.Phone, data.Gender.ToString(), data.DisplayEmail, data.DOB.ToString(),
                            data.Address, data.LevelApply, data.JobExperience, data.Education))
            {
                throw new MissingFieldException("job not completed yet");
            }
            data.IsFinding = true;
            data.IsDelete = false;
            return _context.Create(data);
        }

        public int CreateById(CurriculumVitae data, int id)
        {
            if (Validation.checkStringIsEmpty(data.DisplayName, data.Phone, data.Gender.ToString(), data.DisplayEmail, data.DOB.ToString(),
                            data.Address, data.LevelApply, data.JobExperience, data.Education))
            {
                throw new MissingFieldException("job not completed yet");
            }
            data.IsFinding = true;
            data.IsDelete = false;
            return _context.CreateById(data, id);
        }

        public int Delete(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public List<CurriculumVitae> getAll()
        {
            throw new NotImplementedException();
        }

        public List<CurriculumVitae> getAllById(int id)
        {
            return _context.GetAllById(id);
        }

        public Task<string> GetResult(string prompt)
        {
            throw new NotImplementedException();
        }

        public int Update(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }
    }
}
