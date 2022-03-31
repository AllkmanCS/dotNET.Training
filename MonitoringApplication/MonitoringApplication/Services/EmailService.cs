using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;
using MailKit.Net.Smtp;

namespace MonitoringApplication.Services
{
    public class EmailService : IEmailService
    {
        private readonly WebsiteConfigurations _configurations;

        public EmailService(IOptions<WebsiteConfigurations> configurations)
        {
            _configurations = configurations.Value;
        }

        public void Send()
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configurations.AdminEmail));
            email.To.Add(MailboxAddress.Parse(_configurations.AdminEmail));
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
