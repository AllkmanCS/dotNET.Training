namespace ListenersConfigurationLibrary.ListenersConfigurations
{
    public class EventLogListenerConfiguration
    {
        public string EventLogName { get; set; }
        public string MinLogLevel { get; set; }
        public const string SectionName = "eventLogListener";
    }
}
