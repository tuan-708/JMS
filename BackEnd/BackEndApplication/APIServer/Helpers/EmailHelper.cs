using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace APIServer.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendMail(string email, string message)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);
            var username = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];

            try
            {
                var messageToSend = new MimeMessage();
                messageToSend.From.Add(new MailboxAddress("JMS Support", username));
                messageToSend.To.Add(new MailboxAddress("Recipient Name", email));
                messageToSend.Subject = "Quên mật khẩu";


                var htmlPart = new TextPart("html")
                {
                    Text = message
                };

                var multipart = new Multipart("alternative");
                multipart.Add(htmlPart);

                messageToSend.Body = multipart;

                // Kết nối đến máy chủ SMTP và gửi email
                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, port, SecureSocketOptions.StartTls);

                    // Đăng nhập bằng tên đăng nhập và mật khẩu của bạn
                    client.Authenticate(username, password);

                    // Gửi email
                    client.Send(messageToSend);

                    client.Disconnect(true);
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
