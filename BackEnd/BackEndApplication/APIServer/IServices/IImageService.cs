using Microsoft.AspNetCore.Http;

namespace APIServer.IServices
{
    public interface IImageService
    {
        public int updateImageCandidate(int candidatId, IFormFile file);
        public int updateImageCV(int cvId, IFormFile file);
        public int updateImageRecuirter(int recuirterId, IFormFile file);
        public int updateImageAvtCompany(int companyId, int recuirterId, IFormFile file);
        public int updateImageBgrCompany(int companyId, int recuirterId, IFormFile file);
    }
}
