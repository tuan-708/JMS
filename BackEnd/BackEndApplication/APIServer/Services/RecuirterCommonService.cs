using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class RecuirterCommonService : IRecurterCommon
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IBaseRepository<Gender> genderRepo;
        private readonly IBaseRepository<EmploymentType> empRepo;
        private readonly IBaseRepository<Level> levelRepo;
        private readonly IBaseRepository<Category> catRepo;

        public RecuirterCommonService(IMapper mapper, IConfiguration configuration, IBaseRepository<Gender> genderRepo, IBaseRepository<EmploymentType> empRepo, IBaseRepository<Level> levelRepo, IBaseRepository<Category> catRepo)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.genderRepo = genderRepo;
            this.empRepo = empRepo;
            this.levelRepo = levelRepo;
            this.catRepo = catRepo;
        }

        public List<EmploymentTypeDTO> allEmploymentType()
        {
            var data = empRepo.GetAll();
            return mapper.Map<List<EmploymentTypeDTO>>(data);
        }

        public List<CategoryDTO> getAllCategory()
        {
            return mapper.Map<List<CategoryDTO>>(catRepo.GetAll());
        }

        public List<Gender> getAllGender()
        {
            return genderRepo.GetAll();

        }

        public List<LevelDTO> getAllLevel()
        {
            return mapper.Map<List<LevelDTO>>(levelRepo.GetAll());
        }
    }
}
