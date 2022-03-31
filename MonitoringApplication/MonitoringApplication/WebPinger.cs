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
        public WebPinger(WebsiteConfigurations configurations)
        {
            _url = configurations.Url;
            _responseTime = configurations.ResponseTime;
        }
        public async Task SendPing()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            while (sw.Elapsed.TotalSeconds < 100000)
            {
                Ping pinger = new Ping();
                PingReply pingReply = pinger.Send(_url, _responseTime);
                Console.WriteLine(pingReply.RoundtripTime); 
                if (pingReply.RoundtripTime < _responseTime)
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
            //Thread.Sleep(timeInterval);
        }
    }
}
