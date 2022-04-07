using Microsoft.Extensions.Logging;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;
using MonitoringApplication.Services;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MonitoringApplication
{
    internal class WebPinger : IWebPinger
    {
        private WebsiteConfigurations _configurations = new WebsiteConfigurations();
        private string _url;
        private int _responseTime;
        private IEmailService _emailService = new EmailService();
        private ILogService _logService = new LogService();
        private HttpClient _httpClient = new HttpClient();
        public WebPinger(WebsiteConfigurations configurations)
        {
            _url = configurations.Url;
            _responseTime = configurations.ResponseTime;
        }
        public async Task SendPing(CancellationToken cancellationToken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalMilliseconds < 10000)
            {
                Console.WriteLine(sw.Elapsed.TotalMilliseconds);
                var request = _httpClient.GetAsync(_url, cancellationToken);
                if (request.IsCompletedSuccessfully)
                {
                    _logService.Log();
                    Console.WriteLine("Logged!");
                }
                else
                {
                    await _emailService.Send();
                    Console.WriteLine("Email sent!");
                }
                await Task.Delay(_configurations.CheckInterval);
            }
        }
    }
}
