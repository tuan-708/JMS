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
            if (candidatId <= 0)
                throw new Exception("Data not valid");

            return -1;
        }

        public int updateImageCV(int cvId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public int updateImageRecuirter(int recuirterId, IFormFile file)
        {
            try
            {
                if (recuirterId <= 0)
                    throw new Exception("Data not valid");
                var rec = recuirterRepository.GetById(recuirterId);
                if (rec == null)
                    throw new Exception("Not found");
                if (rec.AvatarURL != null)
                {
                    deleteOldImg(rec.AvatarURL);
                }
                string FileName = file.FileName;
                string uniqueFileName = Guid.NewGuid().ToString() + "_Recuirter_" + FileName;
                uploadImg(file, uniqueFileName);
                var imagePath = Path.Combine("\\wwwroot\\images\\", uniqueFileName);
                rec.AvatarURL = imagePath;
                return recuirterRepository.Update(rec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void uploadImg(IFormFile file, string fileName)
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
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
                using(var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
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

        private void deleteOldImg(string? url)
        {
            var dir = Directory.GetCurrentDirectory();
            var path = dir + url;
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
