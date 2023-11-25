using APIServer.IRepositories;
using APIServer.IServices;

namespace APIServer.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRecuirterRepository _recruiterRepository;
        private readonly IConfiguration _configuration;


        public RegisterService(ICandidateRepository candidateRepository, IRecuirterRepository recruiterRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _candidateRepository = candidateRepository;
            _recruiterRepository = recruiterRepository;
        }
        public string RegisterForCandidate(string email, string fullName, string username, string password, string confirmPassword)
        {
            bool isEmailExist = _candidateRepository.IsEmailExist(email);
            bool isUsernameExist = _candidateRepository.IsUsernameExist(username);
            if (!isEmailExist && !isUsernameExist)
            {
                if (password.Equals(confirmPassword))
                {
                    int register = _candidateRepository.Register(email, fullName, username, password);
                    if (register > 0) return "Register successful";
                    else return "Register failed";

                }
                else return "Password and confirmPassword are not matching";
            }
            else if(isEmailExist) return "Email exist in system";
            else return "Username exist in system";
        }

        public string RegisterForRecruiter(string email, string fullName, string username, string password, string confirmPassword)
        {
            bool isEmailExist = _recruiterRepository.IsEmailExist(email);
            bool isUsernameExist = _recruiterRepository.IsUsernameExist(username);
            if (!isEmailExist && !isUsernameExist)
            {
                if (password.Equals(confirmPassword))
                {
                    int register = _recruiterRepository.Register(email, fullName, username, password);
                    if (register > 0) return "Register successful";
                    else return "Register failed";

                }
                else return "Password and confirmPassword are not matching";
            }
            else if (isEmailExist) return "Email exist in system";
            else return "Username exist in system";
        }
    }
}
