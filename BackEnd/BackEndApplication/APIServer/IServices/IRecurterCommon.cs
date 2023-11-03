using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IRecurterCommon
    {
        public List<Gender> getAllGender();
        public List<CategoryDTO> getAllCategory();
        public List<LevelDTO> getAllLevel();
        public List<EmploymentTypeDTO> allEmploymentType();
    }
}
