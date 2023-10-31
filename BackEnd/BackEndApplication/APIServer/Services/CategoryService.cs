using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class CategoryService : IBaseService<CategoryDTO>
    {
        private readonly IBaseRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CategoryService(IBaseRepository<Category> categoryRepo, IMapper mapper, IConfiguration configuration)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public int Create(CategoryDTO data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(CategoryDTO data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(CategoryDTO data)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDTO> getAll()
        {
            return _mapper.Map<List<CategoryDTO>>(_categoryRepo.GetAll());
        }

        public List<CategoryDTO> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(CategoryDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
