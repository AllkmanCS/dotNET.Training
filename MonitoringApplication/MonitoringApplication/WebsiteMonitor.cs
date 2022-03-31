using Microsoft.Extensions.Configuration;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;

namespace MonitoringApplication
{
    public class WebsiteMonitor
    {

        private string[] _paths = { "msDocs", "delfi" };
        private List<IWebPinger> _pingers = new List<IWebPinger>(); //Ping()
        private List<WebsiteConfigurations> _websites; //Ping()
        private IConfigurationRoot _config;
        public WebsiteMonitor()
        {
            _websites = new List<WebsiteConfigurations>();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/MonitoringApplication/MonitoringApplication/appsettings.json");
            var config = builder.Build();
            ReadJsonSettings(config);
        }
        private void ReadJsonSettings(IConfigurationRoot config)
        {
            foreach (var item in _paths)
            {
                switch (item)
                {
                    case "msDocs":
                        _websites.Add(config.GetSection(_paths[0]).Get<WebsiteConfigurations>());
                        break;
                    case "delfi":
                        _websites.Add(config.GetSection(_paths[1]).Get<WebsiteConfigurations>());
                        break;
                    default:
                        break;
                }
            }
        }
        public async Task Initialize()
        {
            foreach (var item in _websites)
            {
                _pingers.Add(new WebPinger(item));
            }
            return;
        }
        public async Task StartMonitoring()
        {
            List<Task> tasks = new List<Task>();
            
            foreach (var item in _pingers)
            {
                tasks.Add(item.Ping());
            }
            await Task.WhenAll(tasks);
        }
    }
}