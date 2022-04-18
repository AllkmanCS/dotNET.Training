using ListenersConfigurationLibrary.ListenersConfigurations;
using ListenersRepository;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace EventLogListenerLibrary
{
    public class EventLogListener : IListener
    {
        //drawback is that in here it can also reach FileName....
        public string EventLogName { get; set; }
        public string MinLogLevel { get; set; }
        public EventLogListener()
        {
        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\eventLogListenerSettings.json");
        string jsonFile = Path.GetFullPath(sFile);
            IConfigurationBuilder builder = new ConfigurationBuilder()
                     .AddJsonFile(jsonFile);
            var config = builder.Build();
            var eventLogConfig = config.GetSection(EventLogListenerConfiguration.SectionName)
                .Get<EventLogListenerConfiguration>();
            EventLogName = eventLogConfig.EventLogName;
            MinLogLevel = eventLogConfig.MinLogLevel;
            //FileName -----------
        }
        public void Write(string message)
        {
            // Create an instance of EventLog
            EventLog eventLog = new EventLog();

            // Check if the event source exists. If not create it.
            if (!EventLog.SourceExists("TestApplication"))
            {
                EventLog.CreateEventSource("TestApplication", "Application");
            }

            // Set the source name for writing log entries.
            eventLog.Source = "TestApplication";

            // Create an event ID to add to the event log
            int eventID = 8;

            // Write an entry to the event log.
            eventLog.WriteEntry(message,
                                EventLogEntryType.Information,
                                eventID);

            // Close the Event Log
            eventLog.Close();
        }
    }
}