using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.Services
{
    public class ImageService : IImageService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IRecuirterRepository recuirterRepository;
        private readonly IBaseRepository<Company> companyRepo;

        public ImageService(IMapper mapper, IConfiguration configuration, IRecuirterRepository recuirterRepository, IBaseRepository<Company> companyRepo)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.recuirterRepository = recuirterRepository;
            this.companyRepo = companyRepo;
        }

        public int updateImageAvtCompany(int companyId, int recuirterId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public int updateImageBgrCompany(int companyId, int recuirterId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public int updateImageCandidate(int candidatId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public int updateImageCV(int cvId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public int updateImageRecuirter(int recuirterId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        private void uploadImg(IFormFile file)
        {
            try
            {
                string fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!IsImageFileExtension(fileExtension))
                {
                    throw new Exception("Only allow img file");
                }
                if (!IsImageFileSizeValid(file, 25))
                {
                    throw new Exception("Only allow img size under 25mb");
                }
                string FileName = file.FileName;
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", uniqueFileName);
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsImageFileExtension(string fileExtension)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            return allowedExtensions.Contains(fileExtension);
        }

        private bool IsImageFileSizeValid(IFormFile file, int maxSizeInMB)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

            long fileSizeInBytes = file.Length;
            long fileSizeInMB = fileSizeInBytes / 1024 / 1024;

            return fileSizeInMB <= maxSizeInMB;
        }
    }
}
