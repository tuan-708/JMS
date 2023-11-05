using APIServer.Models.Entity;
using Microsoft.AspNetCore.Http;

namespace APIServer.IServices
{
    public interface IImageService
    {
        public string updateImageCandidate(int candidatId, IFormFile file);
        public string updateImageCV(int candidateId,int cvId, IFormFile file);
        public string updateImageRecuirter(int recuirterId, IFormFile file);
        public string updateImageAvtCompany(int companyId, int recuirterId, IFormFile file);
        public string updateImageBgrCompany(int companyId, int recuirterId, IFormFile file);
        public string addImgSlider(IFormFile file, Slider slider);
        public int deleteImgSlider(int id);
        public List<Slider> getAllSlider();
    }
}
