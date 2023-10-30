using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class EmploymentTypeService : IBaseService<EmploymentTypeDTO>
    {
        private readonly IBaseRepository<EmploymentType> _empTypeRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public EmploymentTypeService(IBaseRepository<EmploymentType> empTypeRepo, IMapper mapper, IConfiguration configuration)
        {
            _empTypeRepo = empTypeRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(EmploymentTypeDTO data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(EmploymentTypeDTO data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(EmploymentTypeDTO data)
        {
            throw new NotImplementedException();
        }

        public List<EmploymentTypeDTO> getAll()
        {
            var rs = _empTypeRepo.GetAll();
            return _mapper.Map<List<EmploymentTypeDTO>>(rs);
        }

        public List<EmploymentTypeDTO> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public EmploymentTypeDTO? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(EmploymentTypeDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
