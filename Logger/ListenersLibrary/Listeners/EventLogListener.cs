﻿using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenersConfigurations;
using System.Diagnostics;

namespace ListenersLibrary.Listeners
{
    public class EventLogListener : IListener
    {
        private string _eventLogName;
        public string MinLogLevel { get; }
        public EventLogListener(EventLogListenerConfiguration configuration)
        {
            _eventLogName = configuration.EventLogName;
            MinLogLevel = configuration.MinLogLevel;
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
