using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace MonitoringApplication.Services
{
    public class EmailService : IEmailService
    {
        private string _email;
        public EmailService(WebsiteConfigurations configurations)
        {
            _email = configurations.AdminEmail;
        }
        public EmailService()
        {

        }
        public async Task Send()
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_email));
            email.To.Add(MailboxAddress.Parse(_email));
            email.Subject = "WebsiteMonitor Alert!";
            email.Body = new TextPart(TextFormat.Plain) { Text = "Website timeout!" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("Algirdas", "Cern");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
