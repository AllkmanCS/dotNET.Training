using Microsoft.Extensions.Logging;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;
using System.Diagnostics;

namespace MonitoringApplication
{
    internal class WebPinger : IWebPinger
    {
        private WebsiteConfigurations _configurations = new WebsiteConfigurations();
        private IEmailService _emailService;
        private ILogger _logger;
        public WebPinger(WebsiteConfigurations configurations)
        {
            _configurations = configurations;
        }
        public async Task Ping()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var httpClient = new HttpClient();
            while (true) //cancellationToken)
            {
                if (sw.Elapsed.TotalSeconds < 10000)
                {

                    var result = await httpClient.GetAsync(_configurations.Url);
                    Console.WriteLine(result);
                    if (result != null)
                    {
                        //Log
                    }
                    else
                    {
                        _emailService.Send();
                    }
                }
                await Task.Delay(_configurations.CheckInterval);
            }
            //Thread.Sleep(timeInterval);
        }
    }
}
