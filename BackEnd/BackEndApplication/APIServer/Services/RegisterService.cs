using APIServer.IRepositories;
using APIServer.IServices;
using System.Text.RegularExpressions;

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
                if (!IsInputValid(email, null, null, null)) return "Email have to < 35 characters and have to correctly format";
                if (!IsInputValid(null, fullName, null, null)) return "Full name have no special character and number, and at least 8 - 35 characters";
                if (!IsInputValid(null, null, username, null)) return "Username at least 6 - 35 characters";
                if (!IsInputValid(null, null, null, password)) return "Password have to have at least 1 Special characters, 1 capital letters, 1 number and have 8 - 35 characters";
                if (password.Equals(confirmPassword))
                {
                    int register = _candidateRepository.Register(email, fullName, username, password);
                    if (register > 0) return "Register successful";
                    else return "Register failed";

                }
                else return "Password and confirmPassword are not matching";
            }
            else if (isEmailExist) return "Email exist in system";
            else return "Username exist in system";
        }

        public string RegisterForRecruiter(string email, string fullName, string username, string password, string confirmPassword)
        {
            bool isEmailExist = _recruiterRepository.IsEmailExist(email);
            bool isUsernameExist = _recruiterRepository.IsUsernameExist(username);
            if (!isEmailExist && !isUsernameExist)
            {
                if (!IsInputValid(email, null, null, null)) return "Email have 10 - 35 characters and have to correctly format";
                if (!IsInputValid(null, fullName, null, null)) return "Full name have no special character and number, and at least 8 - 35 characters";
                if (!IsInputValid(null, null, username, null)) return "Username at least 6 - 35 characters";
                if (!IsInputValid(null, null, null, password)) return "Password have to have at least 1 Special characters, 1 capital letters, 1 number and have 8 - 35 characters";
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

        private bool IsInputValid(string? email, string? fullname, string? username, string? password)
        {
            if (password != null)
            {
                string passwordPattern = @"^(?=.*[!@#$%^&*()-+])(?=.*[0-9])(?=.*[A-Z]).{8,35}$";
                return Regex.IsMatch(password, passwordPattern);
            }
            else if (email != null)
            {
                string emailPattern = @"^.+@.+\..{1,35}$";
                return Regex.IsMatch(email, emailPattern);
            }
            else if (fullname != null)
            {
                string fullnamePattern = @"^[\p{L} ]{8,35}$";
                return Regex.IsMatch(fullname, fullnamePattern);
            }
            else
            {
                string usernamePattern = @"^[a-zA-Z0-9_]{6,35}$";
                return Regex.IsMatch(username, usernamePattern);
            }
        }
    }
}
