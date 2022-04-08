using Microsoft.Extensions.Configuration;
using MonitoringApplication.Configurations;
using MonitoringApplication.Interfaces;
using System.Text;

namespace MonitoringApplication.Services
{
    public class LogService : ILogService
    {
        private string _fileName;
        public LogService()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile(@"C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/MonitoringApplication/MonitoringApplication/appsettings.json");
            var config = builder.Build();
            var logConfig = config.GetSection("logging").Get<LogConfigurations>();
            _fileName = logConfig.FileName;
        }
        public void Log()
        {
            var sb = new StringBuilder();
            string message = "Website response successful.";
            sb.AppendJoin(" ", new DateTime(), message);
            if (File.Exists(_fileName))
            {
                File.WriteAllText(_fileName, sb.ToString());
            }
            else
            {
                using (FileStream fs = File.Create(_fileName))
                {
                    File.WriteAllText(_fileName, sb.ToString());
                }
            }
        }
    }
}
