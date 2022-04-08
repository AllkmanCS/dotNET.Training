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
        private int _checkInterval;
        private IEmailService _emailService = new EmailService();
        private ILogService _logService = new LogService();
        public WebPinger(WebsiteConfigurations configurations)
        {
            _url = configurations.Url;
            _responseTime = configurations.ResponseTime;
            _checkInterval = configurations.CheckInterval;
        }
        public async Task SendPing(CancellationToken cancellationToken)
        {
            while (true)
            {
                var ping = new Ping();
                var response = await ping.SendPingAsync(_url);
                Console.WriteLine(response.RoundtripTime);
                if (response.RoundtripTime < _responseTime)
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
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
