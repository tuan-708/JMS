using APIServer.Helpers;
using APIServer.IRepositories;
using APIServer.IServices;
using System.Text;

namespace APIServer.Services
{
    public class EmailService : IEmailService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRecuirterRepository _recruiterRepository;
        private readonly IConfiguration _configuration;


        public EmailService(ICandidateRepository candidateRepository, IRecuirterRepository recruiterRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _candidateRepository = candidateRepository;
            _recruiterRepository = recruiterRepository;
        }
        public string ForgotPasswordForCandidate(string email)
        {
            bool isEmailExist = _candidateRepository.IsEmailExist(email);
            if (isEmailExist)
            {
                string newPassword = GenerateRandomString(8);
                string message = $@"<p>mật khẩu của bạn là: </p>
                                    <h4>{newPassword}</h4>";
                int updatePassword = _candidateRepository.UpdatePassword(email, newPassword);
                if(updatePassword > 0)
                {
                    EmailHelper emailHelper = new EmailHelper(_configuration);
                    emailHelper.SendMail(email, newPassword);
                    return "send mail successfully";
                }
            }
            
            return "email does not exist! Check again";
        }

        public string ForgotPasswordForRecruiter(string email)
        {

            bool isEmailExist = _recruiterRepository.IsEmailExist(email);
            if (isEmailExist)
            {
                string newPassword = GenerateRandomString(8);
                string message = $@"<p>mật khẩu của bạn là: </p>
                                    <h4>{newPassword}</h4>";
                int updatePassword = _recruiterRepository.UpdatePassword(email, newPassword);
                if (updatePassword > 0)
                {
                    EmailHelper emailHelper = new EmailHelper(_configuration);
                    emailHelper.SendMail(email, newPassword);
                    return "send mail successfully";
                }
            }

            return "email does not exist! Check again";
        }

         

        public string GenerateRandomString(int length)
        {
            Random random = new Random();
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, characters.Length);
                stringBuilder.Append(characters[index]);
            }

            return stringBuilder.ToString();
        }
    }
}
