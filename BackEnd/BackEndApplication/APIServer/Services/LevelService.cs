using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class LevelService : IBaseService<LevelDTO>
    {
        private readonly IBaseRepository<Level> _levelRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LevelService(IBaseRepository<Level> posRepo, IMapper mapper, IConfiguration configuration)
        {
            _levelRepo = posRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(LevelDTO data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(LevelDTO data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(LevelDTO data)
        {
            throw new NotImplementedException();
        }

        public List<LevelDTO> getAll()
        {
            var data = _levelRepo.GetAll();
            return _mapper.Map<List<LevelDTO>>(data);
        }

        public List<LevelDTO> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public LevelDTO? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LevelDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
