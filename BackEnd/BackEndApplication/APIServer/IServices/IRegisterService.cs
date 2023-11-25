namespace APIServer.IServices
{
    public interface IRegisterService
    {
        public string RegisterForCandidate(string email, string fullName, string username, string password, string confirmPassword);
        public string RegisterForRecruiter(string email, string fullName, string username, string password, string confirmPassword);
    }
}
