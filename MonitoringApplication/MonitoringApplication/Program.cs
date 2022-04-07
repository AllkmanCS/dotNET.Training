using Microsoft.Extensions.Logging.Console;
using MonitoringApplication;
using MonitoringApplication.Configurations;
using MonitoringApplication.Services;
using System.Net;
class Program
{
    static async Task Main(string[] args)
    {
        bool isMutexOwned;
        //Then create a Mutex instance and control this Mutex via isMutexOwned boolean var.
        using (Mutex mut = new Mutex(true, "My Mutex", out isMutexOwned))
        {
            if (isMutexOwned)
            {
                WebsiteMonitor websiteMonitor = new WebsiteMonitor();
                LogService logService = new LogService();
                Console.WriteLine(logService);
                websiteMonitor.Initialize();
                websiteMonitor.StartMonitoring();
                FileSystemWatcher watcher = new FileSystemWatcher();

                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Filter = ".json"; //or to specify full name? appsettings.json
                watcher.Changed += (s, e) =>
                {
                    websiteMonitor.StopMonitoring();
                    websiteMonitor.Initialize();
                    websiteMonitor.StartMonitoring();
                };
            }
           
        }
    }
}