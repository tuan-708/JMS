using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class PositionTitleService : IBaseService<PositionTitleDTO>
    {
        private readonly IBaseRepository<PositionTitle> _posRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PositionTitleService(IBaseRepository<PositionTitle> posRepo, IMapper mapper, IConfiguration configuration)
        {
            _posRepo = posRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(PositionTitleDTO data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(PositionTitleDTO data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(PositionTitleDTO data)
        {
            throw new NotImplementedException();
        }

        public List<PositionTitleDTO> getAll()
        {
            var data = _posRepo.GetAll();
            return _mapper.Map<List<PositionTitleDTO>>(data);
        }

        public List<PositionTitleDTO> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public PositionTitleDTO? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(PositionTitleDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
