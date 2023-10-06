using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IUserService : IBaseService<User>
    {
        public User Login(string? username, string? password);
        public int CreateAdminAccount(User? account, int? adminId);
        public string generateToken(User? userInfo, IConfiguration _configuration);
        public string generateRefreshToken();
        public User getById(int? id);
        public TokenModel regenerateToken(TokenModel? expiredToken, IConfiguration _configuration);
        public void revokeToken(TokenModel? token);
        public int CreateCandidateAccount(User? account);
    }
}
