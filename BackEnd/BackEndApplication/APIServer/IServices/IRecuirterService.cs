using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IRecuirterService : IBaseService<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public string generateToken(Recuirter? userInfo);
        public string generateRefreshToken();
        public Recuirter getById(int? id);
        public TokenModel regenerateToken(TokenModel? expiredToken, IConfiguration _configuration);
        public void revokeToken(TokenModel? token);
        public int CreateRecuirterAccount(Recuirter? account);
    }
}
