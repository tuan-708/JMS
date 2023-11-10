namespace APIServer.IServices
{
    public interface IEmailService
    {
        public string ForgotPasswordForCandidate(string email);
        public string ForgotPasswordForRecruiter(string email);
    }
}
