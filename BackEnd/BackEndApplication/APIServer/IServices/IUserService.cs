using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IUserService : IBaseService<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public int CreateAdminAccount(Recuirter? account, int? adminId);
        public string generateToken(Recuirter? userInfo, IConfiguration _configuration);
        public string generateRefreshToken();
        public Recuirter getById(int? id);
        public TokenModel regenerateToken(TokenModel? expiredToken, IConfiguration _configuration);
        public void revokeToken(TokenModel? token);
        public int CreateCandidateAccount(Recuirter? account);

        public void CreateCandidateCV(CurriculumVitae curriculumVitae);
    }
}
